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

        public ResponseApiError Create(Usuarios usuario)
        {
            try
            {
                ResponseApiError responseApiError = Validate(usuario);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                db.Add(usuario);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError Validate(Usuarios usuario)
        {
            try
            {
                if (usuario.nombre == null || usuario.apellido==null || usuario.correoE==null || usuario.contraseña==null || usuario.nombreUsuario==null || usuario.telefono==null || usuario.perfil>4 )
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
        public List<Usuarios> GetAll()
        {
            try
            {
                // return db.Usuarios.ToList();
                return (from u in db.Usuarios
                        select u
                                           ).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError Update(Usuarios usuario, int id)
        {
            try
            {
                ResponseApiError responseApiError = Validate(usuario);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                responseApiError = ValidateExist(id);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                Usuarios usuarioDb = db.Usuarios.First(x => x.iD_Usuario == id);

                usuarioDb.nombreUsuario = usuario.nombreUsuario;


                db.Update(usuarioDb);
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
            bool existUsuarios = db.Usuarios.Any(x => x.iD_Usuario == id);
            if (!existUsuarios)
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

             
                 Usuarios usuario = db.Usuarios
                     .Include(x=>x.Perfiles)
                     .FirstOrDefault(x => x.iD_Usuario== id);

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
                                join u in db.Usuarios on p.iD_Perfil equals u.perfil
                                where p.iD_Perfil == id
                                select new UsuariosPerfilView
                                {
                                    Name = u.nombre,
                                    Nombre = u.nombreUsuario,
                                    Mail = u.correoE,
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
