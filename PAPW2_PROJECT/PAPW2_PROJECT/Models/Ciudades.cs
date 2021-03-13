using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Ciudades
    {
        public int iD_Ciudad { get; set; }

        public int iD_PaisF { get; set; }

        public string nombre_Ciudad { get; set; }

        public virtual Paises Paises { get; set; }
    }
}
