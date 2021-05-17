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
    public class UsuariosCore
    {
        private PAPW2DbContext db;

        public UsuariosCore(PAPW2DbContext db)
        {
            this.db = db;
        }

     
        public ResponseApiError Validate(CreateUserRequest createUserRequest)
        {
            try
            {
                if (createUserRequest.nombre == null || createUserRequest.apellido==null || createUserRequest.Email==null || createUserRequest.Password==null
                       
                    || createUserRequest.UserName==null || createUserRequest.PhoneNumber==null || createUserRequest.perfil>4 )
                {
                    return new ResponseApiError { Code = 2, Message = "Invalid info", HttpStatusCode = (int)HttpStatusCode.BadRequest};
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Usuario> GetAll()
        {
            try
            {
                // return db.Usuarios.ToList();
                return (from u in db.Usuario
                        select u
                                           ).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError Update(CreateUserRequest createUserRequest, string username)
        {
            try
            {
                ResponseApiError responseApiError = Validate(createUserRequest);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                responseApiError = ValidateExist(username);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                Usuario usuarioDb = db.Usuario.First(x => x.UserName == username);

                usuarioDb.nombre = createUserRequest.nombre; 

                usuarioDb.apellido = createUserRequest.apellido; 

                usuarioDb.Email = createUserRequest.Email; 

                usuarioDb.UserName = createUserRequest.UserName;

                usuarioDb.PhoneNumber = createUserRequest.PhoneNumber;

                usuarioDb.perfil = createUserRequest.perfil; 

                

                db.Update(usuarioDb);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError ValidateExist(string username)
        {
            bool existUsuarios = db.Usuario.Any(x => x.UserName == username);
            if (!existUsuarios)
            {
                return new ResponseApiError { Code = 3, Message = "Doesnt exist", HttpStatusCode = (int)HttpStatusCode.NotFound };
            }

            return null;

        }
        public ResponseApiError Delete(string username)
        {
            try
            {
                ResponseApiError responseApiError = ValidateExist(username);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                 Usuario usuario = db.Usuario
                     .Include(x=>x.Perfiles)
                     .FirstOrDefault(x => x.UserName == username);

                // IQueryable<Perfiles> perfiles = db.Perfiles.Where(x => x.iD_Perfil == id); ESTO VA EN USUARIOS
                //db.RemoveRange(perfiles);

                db.Remove(usuario);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuariosPerfilView> GetUsuariosPerfil(int id)
        {
            try
            {
                UsuariosPerfilView usuariosPerfilView = new UsuariosPerfilView();

                var consulta = (from p in db.Perfiles
                                join u in db.Usuario on p.iD_Perfil equals u.perfil
                                where p.iD_Perfil == id
                                select new UsuariosPerfilView
                                {
                                    Name = u.nombre,
                                    Nombre = u.UserName,
                                    Mail = u.Email,
                                    Perfil = p.tipo_Perfil
                                })
                                .ToList();
                           /*   .GroupBy(x => (x.Name,x.Nombre,x.Mail)
                              .Select(y=> new UsuariosPerfilView
                              {
                                  CompleteInfo=$"{y.Key.Name} {y.Key.Nombre} {y.Key.Mail}",
                                  Perfil=y.Select(z=>z.Perfil)
                              })
                              .ToList();*/
                return consulta;
               
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
    }
}
