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

        public byte[] imagen_URL { get; set; }

        public virtual Noticias Noticias { get; set; }
    }
}
