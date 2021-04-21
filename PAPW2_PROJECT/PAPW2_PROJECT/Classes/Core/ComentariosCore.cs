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
    public class ComentariosCore
    {
        private PAPW2DbContext db;

        public ComentariosCore(PAPW2DbContext db)
        {
            this.db = db;
        }

        public ResponseApiError Create(Comentarios comentario)
        {
            try
            {
                ResponseApiError responseApiError = Validate(comentario);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                db.Add(comentario);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError Validate(Comentarios comentario)
        {
            try
            {
                if (comentario.texto==null || comentario.autor < 0 || comentario.que_Noticia < 0)
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
            bool existComentario = db.Comentarios.Any(x => x.que_Noticia == id);
            if (!existComentario)
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


                Comentarios comentario = db.Comentarios
                    .Include(x => x.Noticias)
                    .FirstOrDefault(x => x.iD_Comentarios == id);

                db.Remove(comentario);
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
