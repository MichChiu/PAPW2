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
    public class SeccionesCore
    {
        private PAPW2DbContext db;

        public SeccionesCore (PAPW2DbContext db)
        {
            this.db = db;
        }

        public ResponseApiError Create(Secciones seccion)
        {
            try
            {
                ResponseApiError responseApiError = Validate(seccion);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                db.Add(seccion);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError Validate(Secciones seccion)
        {
            try
            {
                if (seccion.nombre_Seccion == null || seccion.color < 0 )
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
        public List<Secciones> GetAll()
        {
            try
            {
                return (from s in db.Secciones select s).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError Update(Secciones seccion, int id)
        {
            try
            {
                ResponseApiError responseApiError = Validate(seccion);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                responseApiError = ValidateExist(id);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                Secciones seccionEdit = db.Secciones.First(x => x.iD_Seccion == id);

                seccionEdit.nombre_Seccion = seccion.nombre_Seccion;


                db.Update(seccionEdit);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError ValidateExist(int id)
        {
            bool existSeccion = db.Secciones.Any(x => x.iD_Seccion == id);
            if (!existSeccion)
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


                Secciones seccion = db.Secciones
                    .Include(x => x.Colores)
                    .FirstOrDefault(x => x.iD_Seccion == id);

                db.Remove(seccion);
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
