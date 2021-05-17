using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class LikesUsuarios
    {
        public int iD_NoticiaF { get; set; }

        public int iD_UsuarioF { get; set; }

        public virtual Noticias Noticias { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
