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
        #nullable enable
        public string? nombre_Ciudad { get; set; }
        #nullable disable
        public virtual Paises Paises { get; set; }
        public virtual ICollection<Colonias> Colonias { get; set; }

        public virtual ICollection<Noticias> Noticias { get; set; }

    }
}
