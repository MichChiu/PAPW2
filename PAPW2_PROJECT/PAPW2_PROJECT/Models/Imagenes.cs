using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Imagenes
    {
        public int iD_Imagen { get; set; }

        public int iD_Noticia { get; set; }

        #nullable enable
        public byte[]? imagen_URL { get; set; }
        #nullable disable

        public virtual Noticias Noticias { get; set; }
    }
}
