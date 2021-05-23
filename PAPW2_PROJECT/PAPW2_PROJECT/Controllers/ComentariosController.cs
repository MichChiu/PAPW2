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
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAPW2_PROJECT.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private PAPW2DbContext db;
        private ComentariosCore comentariosCore;
        Logger logger;

        public ComentariosController(PAPW2DbContext db)
        {
            this.db = db;
            logger= NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        // GET: api/<ComentariosController>
        [HttpGet]
        public IActionResult Get()
        {
            comentariosCore = new ComentariosCore(db);
            List<Comentarios> comentarios = comentariosCore.GetAll();
            return Ok(comentarios);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comentarios comentario)
        {
            Claim userIdClaim = User.Claims.FirstOrDefault(x => x.Type.Contains("nameIdentifier"));
            string userId = userIdClaim.Value; 
            try
            {
                comentariosCore = new ComentariosCore(db);
                ResponseApiError responseApiError = comentariosCore.Create(comentario, userId);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Comentario posteado" });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                comentariosCore = new ComentariosCore(db);
                ResponseApiError responseApiError = comentariosCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Comentario Eliminado" });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetComentarioRespuestas([FromRoute] int id)
        {
            comentariosCore = new ComentariosCore(db);
            List<RespuestasComentarioView> respuestas = comentariosCore.GetRespuestasComentarioViews(id);
            return Ok(respuestas);
        }
    }
}
