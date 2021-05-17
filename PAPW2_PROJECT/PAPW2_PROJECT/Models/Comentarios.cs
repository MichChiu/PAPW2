using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Comentarios
    {
        public int iD_Comentarios { get; set; }

        public string texto { get; set; }

        public string autor { get; set; }

        public int que_Noticia { get; set; }

        public virtual Noticias Noticias { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Comentario_Respuestas> Comentario_Respuestas { get; set; }

        public virtual ICollection<NoticiaComentarios> NoticiaComentarios { get; set; }

        public virtual ICollection<Respuestas> Respuestas { get; set; }

    }
}
