using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
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
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private PAPW2DbContext db;
        private UsuariosCore usuariosCore;
        Logger logger;

        public UsuariosController(PAPW2DbContext db)
        {
            this.db = db;
            logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }
        //[Authorize]
        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            usuariosCore = new UsuariosCore(db);
            List<Usuario> usuarios = usuariosCore.GetAll();
            return Ok(usuarios);
        }

        [HttpPut("{username}")]
        public IActionResult Update([FromBody] CreateUserRequest usuario, [FromRoute] string username)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                ResponseApiError responseApiError = usuariosCore.Update(usuario, username);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }
                return Ok(new ResponseApiSuccess { Code = 1, Message = "Usuario modificado" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpDelete("{username}")]
        public IActionResult Delete([FromRoute] string username)
        {
            try
            {
                usuariosCore = new UsuariosCore(db);
                ResponseApiError responseApiError = usuariosCore.Delete(username);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Usuario Eliminado" });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUsuariosPerfil([FromRoute] int id)
        {
            usuariosCore = new UsuariosCore(db);
            List<UsuariosPerfilView> usuarios= usuariosCore.GetUsuariosPerfil(id);
            return Ok(usuarios);
        }
    }
}
