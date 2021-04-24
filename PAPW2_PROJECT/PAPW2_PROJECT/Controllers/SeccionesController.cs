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
    public class SeccionesController : ControllerBase
    {
        private PAPW2DbContext db;
        private SeccionesCore seccionesCore;

        public SeccionesController (PAPW2DbContext db)
        {
            this.db = db;
        }

        // GET: api/<SeccionesController>
        [HttpGet]
        public IActionResult Get()
        {
            seccionesCore = new SeccionesCore(db);
            List<Secciones> secciones = seccionesCore.GetAll();
            return Ok(secciones);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Secciones seccion)
        {
            try
            {
                seccionesCore = new SeccionesCore(db);
                ResponseApiError responseApiError = seccionesCore.Create(seccion);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Seccion creada" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Secciones seccion, [FromRoute] int id)
        {
            try
            {
                seccionesCore = new SeccionesCore(db);
                ResponseApiError responseApiError = seccionesCore.Update(seccion, id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Seccion modificada" });
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
                seccionesCore = new SeccionesCore(db);
                ResponseApiError responseApiError = seccionesCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Seccion Eliminada" });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }





    }
}
