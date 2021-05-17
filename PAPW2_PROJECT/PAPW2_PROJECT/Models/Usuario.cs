using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Usuario: IdentityUser
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int perfil { get; set; }
        public virtual Perfiles Perfiles { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<LikesUsuarios> LikesUsuarios { get; set; }
        public virtual ICollection<Comentarios> Comentarios { get; set; }
        public virtual ICollection<NoticiaComentarios> NoticiaComentarios { get; set; }
        public virtual ICollection<Respuestas> Respuestas { get; set; }
        public virtual ICollection<Comentario_Respuestas> Comentario_Respuestas { get; set; }
    }
}
