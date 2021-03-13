using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Colores
    {
        public int iD_Color { get; set; }

        public string nombre_Color { get; set; }

        public virtual ICollection<Secciones> Secciones { get; set; }
    }
}
