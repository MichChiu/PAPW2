using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Comentario_Respuestas
    {
        public int iD_ComentarioF { get; set; }

        public int iD_RespuestaF { get; set; }

        public int iD_UsuarioF { get; set; }

        public virtual Comentarios Comentarios { get; set; }

        public virtual Respuestas Respuestas { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
