using Microsoft.EntityFrameworkCore;
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


        public PAPW2DbContext ()
        {

        }
        public void OnConfiguring(DbContextOptions optionsBuilder)
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
                /*FALTAAAAAN*/

                usuarios.Property(e => e.perfil).IsRequired();

                usuarios
                .HasOne(e => e.Perfiles)
                .WithMany(y => y.Usuarios)
                .HasForeignKey("const_Perfil");
            });

           
        }
    }
}
