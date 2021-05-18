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
    public class PerfilesController : ControllerBase
    {
        private PAPW2DbContext db;
        private PerfilesCore perfilesCore;
        Logger logger;

        public PerfilesController(PAPW2DbContext db)
        {
            this.db = db;
            logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        // GET: api/<PerfilesController>
        [HttpGet]
        public IActionResult Get()
        {
            perfilesCore = new PerfilesCore(db);
            List<Perfiles> perfiles = perfilesCore.GetAll();
            return Ok(perfiles);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Perfiles perfil)
        {
            try
            {
                perfilesCore = new PerfilesCore(db);
                ResponseApiError responseApiError = perfilesCore.Create(perfil);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Perfil creado" });

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Perfiles perfil, [FromRoute] int id)
        {
            try
            {
                perfilesCore = new PerfilesCore(db);
                ResponseApiError responseApiError = perfilesCore.Update(perfil, id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Perfil modificado" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                perfilesCore = new PerfilesCore(db);
                ResponseApiError responseApiError = perfilesCore.Delete(id);

                if (responseApiError != null)
                {
                    return StatusCode(responseApiError.HttpStatusCode, responseApiError);
                }

                return Ok(new ResponseApiSuccess { Code = 1, Message = "Perfil Eliminado" });

            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseApiError { Code = 1001, Message = ex.Message });
            }

        }
        
    }
}
