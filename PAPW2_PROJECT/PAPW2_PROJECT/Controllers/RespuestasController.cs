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
    public class RespuestasController : ControllerBase
    {
        private PAPW2DbContext db;
        private RespuestasCore respuestasCore;

        public RespuestasController(PAPW2DbContext db)
        {
            this.db = db;
        }
        // GET: api/<RespuestasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Create([FromBody] Respuestas respuesta)
        {
            try
            {
                respuestasCore = new RespuestasCore(db);
                ResponseApiError responseApiError = respuestasCore.Create(respuesta);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Respuesta posteada" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }

        // DELETE api/<RespuestasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                respuestasCore = new RespuestasCore(db);
                ResponseApiError responseApiError = respuestasCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Respuesta Eliminada" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }
    }
}
