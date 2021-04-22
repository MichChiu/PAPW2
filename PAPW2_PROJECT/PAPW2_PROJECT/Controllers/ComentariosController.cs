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
    public class ComentariosController : ControllerBase
    {
        private PAPW2DbContext db;
        private ComentariosCore comentariosCore;

        public ComentariosController(PAPW2DbContext db)
        {
            this.db = db;
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
            try
            {
                comentariosCore = new ComentariosCore(db);
                ResponseApiError responseApiError = comentariosCore.Create(comentario);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Comentario posteado" });

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
                comentariosCore = new ComentariosCore(db);
                ResponseApiError responseApiError = comentariosCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Noticia Eliminada" });

            }
            catch (Exception ex)
            {
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
