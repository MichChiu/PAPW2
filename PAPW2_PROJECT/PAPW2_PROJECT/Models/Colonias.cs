using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Colonias
    {
        public int iD_Colonia { get; set; }

        public int iD_CiudadF { get; set; }

        public string nombre_Colonia { get; set; }

        public virtual Ciudades Ciudades { get; set; }
    }
}
