using PAPW2_PROJECT.Models;
using PAPW2_PROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Classes.Core
{
    public class PerfilesCore
    {
        private PAPW2DbContext db;

        public PerfilesCore(PAPW2DbContext db)
        {
            this.db = db;
        }
        public ResponseApiError Create(Perfiles perfil)
        {
            try
            {
                ResponseApiError responseApiError = Validate(perfil);
                if (responseApiError != null)
                {
                    return responseApiError;
                }
                
                db.Add(perfil);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ResponseApiError Validate(Perfiles perfil)
        {
            try
            {
                if (perfil.tipo_Perfil==null)
                {
                    return new ResponseApiError { Code = 2, Message = "Invalid info", HttpStatusCode = (int)HttpStatusCode.BadRequest };
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public List<Perfiles> GetAll()
        {
            try
            {
               // return db.Perfiles.ToList();
                return (from p in db.Perfiles
                                           select p
                                           ).ToList();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ResponseApiError Update(Perfiles perfil, int id)
        {
            try
            {
                ResponseApiError responseApiError = Validate(perfil);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                responseApiError = ValidateExist(id);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                Perfiles perfilDb = db.Perfiles.First(x => x.iD_Perfil == id);
                perfilDb.tipo_Perfil = perfil.tipo_Perfil;


                db.Update(perfilDb);
                db.SaveChanges();
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ResponseApiError ValidateExist(int id)
        {
            bool existPerfil = db.Perfiles.Any(x => x.iD_Perfil == id);
            if (!existPerfil)
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

                Perfiles perfil = db.Perfiles.FirstOrDefault(x => x.iD_Perfil == id);
                //Perfiles perfil = db.Perfiles.Find(id); OTRO TIPODE BUSQUEDA
          

                db.Remove(perfil);
                db.SaveChanges();

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
