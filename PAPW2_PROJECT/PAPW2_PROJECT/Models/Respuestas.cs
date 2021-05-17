using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Respuestas
    {
        public int iD_Respuesta { get; set; }

        public string respuesta_Texto { get; set; }

        public string autor { get; set; }

        public int que_Comentario { get; set; }

        public virtual Comentarios Comentarios { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Comentario_Respuestas> Comentario_Respuestas { get; set; }

    }
}
