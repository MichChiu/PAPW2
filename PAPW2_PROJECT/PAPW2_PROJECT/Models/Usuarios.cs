using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Usuarios: IdentityUser
    {
        public int iD_Usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        #nullable enable
        public byte[]? pp { get; set; }
        #nullable disable
        public string correoE { get; set; }
        public string contraseña { get; set; }
        public string nombreUsuario { get; set; }
        public string telefono { get; set; }
        public int perfil { get; set; }
        public virtual Perfiles Perfiles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<LikesUsuarios> LikesUsuarios { get; set; }
        public virtual ICollection<Comentarios> Comentarios { get; set; }
        public virtual ICollection<NoticiaComentarios> NoticiaComentarios { get; set; }
        public virtual ICollection<Respuestas> Respuestas { get; set; }
        public virtual ICollection<Comentario_Respuestas> Comentario_Respuestas { get; set; }
    }
}
