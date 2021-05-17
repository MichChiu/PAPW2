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
    public class NoticiasController : ControllerBase
    {
        private PAPW2DbContext db;
        private NoticiasCore noticiasCore;

        public NoticiasController(PAPW2DbContext db)
        {
            this.db = db;
        }

        // GET: api/<NoticiasController>
        [HttpGet]
        public IActionResult Get()
        {
            noticiasCore = new NoticiasCore(db);
            List<Noticias> noticias = noticiasCore.GetAll();
            return Ok(noticias);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Noticias noticia)
        {
            try
            {
                noticiasCore = new NoticiasCore(db);
                ResponseApiError responseApiError = noticiasCore.Create(noticia);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Noticia creada" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Noticias noticia, [FromRoute] int id)
        {
            try
            {
                noticiasCore = new NoticiasCore(db);
                ResponseApiError responseApiError = noticiasCore.Update(noticia, id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Noticia modificada" });
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
                noticiasCore = new NoticiasCore(db);
                ResponseApiError responseApiError = noticiasCore.Delete(id);

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

        [HttpGet("{username}")]
        public IActionResult GetNoticiasUsuario([FromRoute] string username)
        {
            noticiasCore = new NoticiasCore(db);
            List<NoticiasUsuarioView>noticias= noticiasCore.GetNoticiasUsuario(username);
            return Ok(noticias);
        }

        [HttpGet("{id}")]
        public IActionResult GetNoticiasComentario([FromRoute] int id)
        {
            noticiasCore = new NoticiasCore(db);
            List<NoticiasComentarioView> comentarios= noticiasCore.GetNoticiasComentarios(id);
            return Ok(comentarios);
        }
    }
}
