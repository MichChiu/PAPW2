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

        public int pos { get; set; }

        public virtual Colores Colores { get; set; }
    }
}
