using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class NoticiaComentarios
    {
        public int iD_NoticiasF { get; set; }

        public int iD_ComentarioF { get; set; }

        public int iD_UsuarioF { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Noticias Noticias { get; set; }

        public virtual Comentarios Comentarios { get; set; } // se supoe es una llave foranea 

    }
}
