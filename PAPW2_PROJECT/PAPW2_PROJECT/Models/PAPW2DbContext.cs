using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class PAPW2DbContext : DbContext
    {
        public DbSet<Perfiles>Perfiles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }


        public PAPW2DbContext ()
        {

        }

        public PAPW2DbContext(DbContextOptions<PAPW2DbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfiles>().HasKey(perfiles => perfiles.iD_Perfil);
            modelBuilder.Entity<Perfiles>(perfiles =>
            {
                perfiles.Property(e => e.tipo_Perfil)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(usuarios=>
            {
                usuarios.HasKey(e => e.iD_Usuario);
                usuarios.Property(e => e.nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();
                usuarios.Property(e => e.apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();
                usuarios.Property(e => e.pp)
                    .HasMaxLength(600);
                usuarios.Property(e => e.correoE)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();
                usuarios.Property(e => e.contraseña)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .IsRequired();
                usuarios.Property(e => e.nombreUsuario)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .IsRequired();
                usuarios.Property(e => e.telefono)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .IsRequired();

                usuarios.Property(e => e.perfil)
                    .IsRequired();

                usuarios
                .HasOne(e => e.Perfiles)
                .WithMany(y => y.Usuarios)
                .HasForeignKey(e=>e.perfil)
                //.HasForeignKey("const_Perfil")
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Colores>(colores =>
            {
                colores.HasKey(e => e.iD_Color);
                colores.Property(e => e.nombre_Color)
                .HasMaxLength(255)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Secciones>(secciones =>
            {
                secciones.HasKey(e => e.iD_Seccion);
                secciones.Property(e => e.nombre_Seccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
                secciones.Property(e => e.color)
                    .IsRequired();
                secciones.Property(e => e.pos);
                secciones
                .HasOne(e => e.Colores)
                .WithMany(y => y.Secciones)
                .HasForeignKey(e=>e.color)
                //.HasForeignKey("const_Color")
                .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Estatus>(estatus =>
            {
                estatus.HasKey(e => e.iD_Estatus);
                estatus.Property(e => e.nombre_Estatus)
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paises>(paises =>
            {
                paises.HasKey(e => e.iD_Pais);
                paises.Property(e => e.nombre_Pais)
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Ciudades>(ciudades =>
            {
                ciudades.HasKey(e => e.iD_Ciudad);
                ciudades.Property(e => e.iD_PaisF)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
                ciudades.Property(e => e.nombre_Ciudad)
                .HasMaxLength(100)
                .IsUnicode();
                ciudades
                .HasOne(e => e.Paises)
                .WithMany(y => y.Ciudades)
                .HasForeignKey("const_Pais");

            });

            modelBuilder.Entity<Colonias>(colonias =>
            {
                colonias.HasKey(e => e.iD_Colonia);
                colonias.Property(e => e.iD_CiudadF)
                .IsRequired();
                colonias.Property(e => e.nombre_Colonia)
                .HasMaxLength(100)
                .IsUnicode();
                colonias
                .HasOne(e => e.Ciudades)
                .WithMany(y => y.Colonias)
                .HasForeignKey("const_Ciudad");

            });

            modelBuilder.Entity<Noticias>(noticias=>
            {
                noticias.HasKey(e => e.iD_Noticia);
                noticias.Property(e => e.paisF)
                    .IsRequired();
                noticias.Property(e => e.ciudadF)
                   .IsRequired();
                noticias.Property(e => e.coloniaF)
                   .IsRequired();
                noticias.Property(e => e.fecha_Hora_Acontecimiento)
                    .HasColumnType("datetime")
                    .IsUnicode(false)
                   .IsRequired();
                noticias.Property(e => e.fecha_Publicacion)
                    .HasColumnType("datetime")
                    .IsUnicode(false);
                noticias.Property(e => e.autor)
                   .IsRequired();
                noticias.Property(e => e.titulo_Noticia)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .IsRequired();
                noticias.Property(e => e.descripcion_Noticia)
                  .HasMaxLength(100)
                  .IsUnicode(false)
                  .IsRequired();
                noticias.Property(e => e.texto_Noticia)
                  .HasMaxLength(100)
                  .IsUnicode(false)
                  .IsRequired();
                noticias.Property(e => e.palabra_Clave)
                  .HasMaxLength(100)
                  .IsUnicode(false)
                  .IsRequired();
                noticias.Property(e => e.seccion_Noticia)
                   .IsRequired();
                noticias.Property(e => e.estatus_Noticia)
                  .IsRequired();
                noticias.Property(e => e.likes);
                noticias.Property(e => e.visitas);
                noticias.Property(e => e.comentarios_editor)
                  .IsUnicode(false);

                noticias
                .HasOne(e => e.Secciones)
                .WithMany(y => y.Noticias)
                .HasForeignKey(e=>e.seccion_Noticia);
                //.HasForeignKey("const_SeccionN");

                noticias
                .HasOne(e => e.Estatus)
                .WithMany(y => y.Noticias)
                .HasForeignKey(e=>e.estatus_Noticia);
                //.HasForeignKey("const_EstatusN");

                noticias
               .HasOne(e => e.Paises)
               .WithMany(y => y.Noticias)
               .HasForeignKey(e=>e.paisF);
                //.HasForeignKey("const_PaisN");

                noticias
                .HasOne(e => e.Ciudades)
                .WithMany(y => y.Noticias)
                .HasForeignKey(e=>e.ciudadF);
                //.HasForeignKey("const_CiudadN");

                noticias
                .HasOne(e => e.Colonias)
                .WithMany(y => y.Noticias)
                .HasForeignKey(e=>e.coloniaF);
                //.HasForeignKey("const_ColoniaN");

                noticias
                .HasOne(e => e.Usuarios)
                .WithMany(y => y.Noticias)
                .HasForeignKey(e=> e.autor);
                //.HasForeignKey("const_AutN");
            });

            modelBuilder.Entity<LikesUsuarios>(likesusuarios =>
            {
                likesusuarios.HasKey(e => new { e.iD_NoticiaF, e.iD_UsuarioF });
                likesusuarios.Property(e => e.iD_NoticiaF)
                .IsRequired();
                likesusuarios.Property(e => e.iD_UsuarioF)
                .IsRequired();
                likesusuarios
                .HasOne(e => e.Noticias)
                .WithMany(y => y.LikesUsuarios)
                .HasForeignKey("const_Like_Noti");
                likesusuarios
               .HasOne(e => e.Usuarios)
               .WithMany(y => y.LikesUsuarios)
               .HasForeignKey("const_Like_Usu");

            });

            modelBuilder.Entity<Comentarios>(comentarios =>
            {
                comentarios.HasKey(e => e.iD_Comentarios);
                comentarios.Property(e => e.texto)
                .HasMaxLength(1500)
                .IsRequired()
                .IsUnicode(false);
                comentarios.Property(e => e.autor)
                .IsRequired();
                comentarios.Property(e => e.que_Noticia)
                .IsRequired();
                comentarios
                .HasOne(e => e.Noticias)
                .WithMany(y => y.Comentarios)
                .HasForeignKey("const_QueNoti");
                comentarios
               .HasOne(e => e.Usuarios)
               .WithMany(y => y.Comentarios)
               .HasForeignKey("const_Coment_Aut");

            });

          modelBuilder.Entity<NoticiaComentarios>(noticiaComentarios =>
              {
                  noticiaComentarios.HasKey(e => new { e.iD_NoticiasF, e.iD_ComentarioF, e.iD_UsuarioF });
                  noticiaComentarios.Property(e => e.iD_NoticiasF)
                  .IsRequired();
                  noticiaComentarios.Property(e => e.iD_ComentarioF)
                  .IsRequired();
                  noticiaComentarios.Property(e => e.iD_UsuarioF)
                  .IsRequired();
                  noticiaComentarios
                  .HasOne(e => e.Usuarios)
                  .WithMany(y => y.NoticiaComentarios)
                  .HasForeignKey("const_NotiComent_Usu");
                  noticiaComentarios
                 .HasOne(e => e.Noticias)
                 .WithMany(y => y.NoticiaComentarios)
                 .HasForeignKey("const_NotiComent_Noti");
                  noticiaComentarios
                  .HasOne(e => e.Comentarios)
                .WithMany(y => y.NoticiaComentarios)
                .HasForeignKey("const_NotiComent_Coment");


              });

            modelBuilder.Entity<Respuestas>(respuestas =>
            {
                respuestas.HasKey(e => e.iD_Respuesta);
                respuestas.Property(e => e.respuesta_Texto)
                .HasMaxLength(1500)
                .IsUnicode(false)
                .IsRequired();
                respuestas.Property(e => e.autor)
                .IsRequired();
                respuestas.Property(e => e.que_Comentario)
                .IsRequired();
                respuestas
                .HasOne(e => e.Comentarios)
                .WithMany(y => y.Respuestas)
                .HasForeignKey("const_QueComent");
                respuestas
               .HasOne(e => e.Usuarios)
               .WithMany(y => y.Respuestas)
               .HasForeignKey("const_Coment_AutRes");

            });
           
            modelBuilder.Entity<Comentario_Respuestas>(comentario_Respuestas =>
            {
                comentario_Respuestas.HasKey(e => new { e.iD_ComentarioF, e.iD_RespuestaF, e.iD_UsuarioF });
                comentario_Respuestas.Property(e => e.iD_ComentarioF)
                .IsRequired();
                comentario_Respuestas.Property(e => e.iD_RespuestaF)
                .IsRequired();
                comentario_Respuestas.Property(e => e.iD_UsuarioF)
                .IsRequired();
                comentario_Respuestas
                .HasOne(e => e.Comentarios)
                .WithMany(y => y.Comentario_Respuestas)
                .HasForeignKey("const_ComRes_Coment");
                comentario_Respuestas
                .HasOne(e => e.Respuestas)
                .WithMany(y => y.Comentario_Respuestas)
                .HasForeignKey("const_ComRes_Respu");
                comentario_Respuestas
                .HasOne(e => e.Usuarios)
                .WithMany(y => y.Comentario_Respuestas)
                .HasForeignKey("const_ComRes_Usu");

            });

            modelBuilder.Entity<Videos>(videos =>
            {
                videos.HasKey(e => e.iD_Video);
                videos.Property(e => e.iD_Noticia)
                    .IsRequired();
                videos.Property(e => e.video_URL)
                .HasMaxLength(1000)
                .IsUnicode(false);
                videos
                .HasOne(e => e.Noticias)
                .WithMany(y => y.Videos)
                .HasForeignKey("const_Vid_Noti");
            });

            modelBuilder.Entity<Imagenes>(imagenes =>
            {
                imagenes.HasKey(e => e.iD_Imagen);
                imagenes.Property(e => e.iD_Noticia)
                    .IsRequired();
                imagenes.Property(e => e.imagen_URL)
                .HasMaxLength(1000)
                .IsUnicode(false);
                imagenes
                .HasOne(e => e.Noticias)
                .WithMany(y => y.Imagenes)
                .HasForeignKey("const_Vid_Noti");
            });

        }
    }
}
