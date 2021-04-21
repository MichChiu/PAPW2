using Microsoft.AspNetCore.Mvc;
using PAPW2_PROJECT.Classes.Core;
using PAPW2_PROJECT.Models;
using PAPW2_PROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAPW2_PROJECT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private PAPW2DbContext db;
        private UsuariosCore usuariosCore;
       
        public UsuariosController(PAPW2DbContext db)
        {
            this.db = db;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            usuariosCore = new UsuariosCore(db);
            List<Usuarios> usuarios = usuariosCore.GetAll();
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuarios usuario)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                ResponseApiError responseApiError = usuariosCore.Create(usuario);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Usuario creado" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Usuarios usuario, [FromRoute] int id)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                ResponseApiError responseApiError = usuariosCore.Update(usuario, id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Usuario modificado" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                ResponseApiError responseApiError = usuariosCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Usuario Eliminado" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUsuariosPerfil([FromRoute] int id)
        {
            usuariosCore = new UsuariosCore(db);
            usuariosCore.GetUsuariosPerfil(id);
            return Ok();
        }
    }
}
