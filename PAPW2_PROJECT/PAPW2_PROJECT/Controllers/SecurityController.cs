using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAPW2_PROJECT.Classes.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PAPW2_PROJECT.Models;
using PAPW2_PROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private PAPW2DbContext db;
        private UsuariosCore usuariosCore;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;

        public SecurityController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                usuariosCore.Validate(createUserRequest);
                var result = await _userManager.CreateAsync(new Usuario
                {
                    nombre=createUserRequest.nombre,
                    Email = createUserRequest.Email,
                    UserName = createUserRequest.UserName,
                    PhoneNumber=createUserRequest.PhoneNumber,
                    perfil=createUserRequest.perfil

                }, createUserRequest.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(500, "Error en creacion de usuario");
                }
                return Ok("Usuario creado");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                Usuario user = await _userManager.FindByNameAsync(login.UserName);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                    if (!result.Succeeded) 
                    {
                        return StatusCode(404, "Usuario o contraseña invalidos");
                    }
                    else
                    {
                        var secretkey = _configuration.GetValue<string>("SecretKey");
                        var key = Encoding.ASCII.GetBytes(secretkey);

                        var claims = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Name,user.UserName)
                        });

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject= claims,
                            Expires=DateTime.UtcNow.AddDays(1),
                            SigningCredentials= new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();

                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                        return Ok(tokenHandler.WriteToken(createdToken));
                    }
                }
                else
                {
                    return StatusCode(404, "Usuario o contraseña invalidos");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
