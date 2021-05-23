﻿using Microsoft.EntityFrameworkCore;
using PAPW2_PROJECT.Models;
using PAPW2_PROJECT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Classes.Core
{
    public class NoticiasCore
    {
        private PAPW2DbContext db;

        public NoticiasCore (PAPW2DbContext db)
        {
            this.db = db;
        }
        public ResponseApiError Create(Noticias noticia, string userId)
        {
            try
            {
                ResponseApiError responseApiError = Validate(noticia, userId);
                if (responseApiError != null)
                {
                    return responseApiError;
                }
                noticia.autor = userId;
                db.Add(noticia);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ResponseApiError Validate(Noticias noticia, string userId)
        {
            try
            {
                if (noticia.paisF < 0 || noticia.ciudadF < 0 || noticia.coloniaF < 0 || noticia.fecha_Hora_Acontecimiento.Year< 2021 || noticia.titulo_Noticia == null|| noticia.descripcion_Noticia==null || noticia.texto_Noticia==null ||
                    noticia.palabra_Clave==null ||noticia.seccion_Noticia<0||noticia.estatus_Noticia<0)
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
        public List<Noticias> GetAll()
        {
            try
            {
                //return db.Noticias.ToList();
                return (from n in db.Noticias select n ).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseApiError Update(Noticias noticia, int id, string userId)
        {
            try
            {
                ResponseApiError responseApiError = Validate(noticia, userId);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                responseApiError = ValidateExist(id);
                if (responseApiError != null)
                {
                    return responseApiError;
                }

                Noticias noticiaEdit = db.Noticias.First(x => x.iD_Noticia == id);

                noticiaEdit.paisF = noticia.paisF;

                noticiaEdit.ciudadF = noticia.ciudadF;

                noticiaEdit.coloniaF = noticia.coloniaF;

                noticiaEdit.fecha_Hora_Acontecimiento = noticia.fecha_Hora_Acontecimiento;

                noticiaEdit.fecha_Publicacion = noticia.fecha_Publicacion;

                noticiaEdit.titulo_Noticia = noticia.titulo_Noticia;

                noticiaEdit.descripcion_Noticia = noticia.descripcion_Noticia;

                noticiaEdit.texto_Noticia = noticia.texto_Noticia;

                noticiaEdit.palabra_Clave = noticia.palabra_Clave;

                noticiaEdit.seccion_Noticia = noticia.seccion_Noticia;

                noticiaEdit.estatus_Noticia = noticia.estatus_Noticia;

                noticiaEdit.likes = noticia.likes;

                noticiaEdit.visitas = noticia.visitas;

                noticiaEdit.comentarios_editor = noticia.comentarios_editor; 

                noticiaEdit.texto_Noticia = noticia.texto_Noticia;

                

                db.Update(noticiaEdit);
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
            bool existNoticia = db.Noticias.Any(x => x.iD_Noticia == id);
            if (!existNoticia)
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


                Noticias noticia = db.Noticias
                    .Include(x => x.Usuario)
                    .FirstOrDefault(x => x.iD_Noticia == id);

                db.Remove(noticia);
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NoticiasUsuarioView> GetNoticiasUsuario(string username)
        {
            try
            {
                NoticiasUsuarioView noticiasUsuarioView = new NoticiasUsuarioView();

                var consulta = (from u in db.Usuario
                                join n in db.Noticias on u.Id equals n.autor
                                where u.UserName == username
                                select new NoticiasUsuarioView
                                {
                                    Name = u.nombre,
                                    NombreUsuario = u.UserName,
                                    Noticias = n.iD_Noticia,
                                    Noticias_Titulo=n.titulo_Noticia,
                                    Noticias_Texto=n.texto_Noticia
                                })

                             /* .GroupBy(x=>(x.Name,x.NombreUsuario))
                              .Select(y=> new NoticiasUsuarioView
                              {
                                  CompleteInfo=$"{y.Key.Name} {y.Key.Nombre}",
                                  Perfil=y.Select(z=>z.Perfil)
                              })*/
                              .ToList();
                return consulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NoticiasComentarioView> GetNoticiasComentarios(int id)
        {
            try
            {
                NoticiasComentarioView noticiasComentarioView = new NoticiasComentarioView();

                var consulta = (from n in db.Noticias
                                join c in db.Comentarios on n.iD_Noticia equals c.que_Noticia
                                where n.iD_Noticia == id
                                select new NoticiasComentarioView
                                {
                                    Noticias = n.iD_Noticia,
                                    Noticias_Titulo = n.titulo_Noticia,
                                    Noticias_Texto = n.texto_Noticia,
                                    Comentario=c.texto
                                })
                              .ToList();
                return consulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
