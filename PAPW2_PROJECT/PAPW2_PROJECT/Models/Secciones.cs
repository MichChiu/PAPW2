using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Secciones
    {
        public int iD_Seccion { get; set; }

        public string nombre_Seccion { get; set; }

        public int color { get; set; }
        #nullable enable
        public int? pos { get; set; }
        #nullable disable

        public virtual Colores Colores { get; set; }

        public virtual ICollection<Noticias> Noticias { get; set; }

    }
}
