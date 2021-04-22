using Microsoft.EntityFrameworkCore;
using PAPW2_PROJECT.Models;
using PAPW2_PROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Classes.Core
{
    public class RespuestasCore
    {
        private PAPW2DbContext db;

        public RespuestasCore(PAPW2DbContext db)
        {
            this.db = db;
        }
        public ResponseApiError Create(Respuestas respuesta)
        {
            try
            {
                ResponseApiError responseApiError = Validate(respuesta);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                db.Add(respuesta);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError Validate(Respuestas respuesta)
        {
            try
            {
                if ( respuesta.respuesta_Texto == null || respuesta.autor < 0 || respuesta.que_Comentario < 0)
                {
                    return new ResponseApiError { Code = 2, Message = "Invalid info", HttpStatusCode = (int)HttpStatusCode.BadRequest };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError ValidateExist(int id)
        {
            bool existRespuesta = db.Respuestas.Any(x => x.iD_Respuesta == id);
            if (!existRespuesta)
            {
                return new ResponseApiError { Code = 3, Message = "Doesnt exist", HttpStatusCode = (int)HttpStatusCode.NotFound };
            }

            return null;
        }
        public ResponseApiError Delete(int id)
        {
            try
            {
                ResponseApiError responseApiError = ValidateExist(id);
                if (responseApiError != null)
                {
                    return responseApiError;
                }


                Respuestas respuesta = db.Respuestas
                    .FirstOrDefault(x => x.iD_Respuesta == id);

                db.Remove(respuesta);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
