using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Paises
    {
        public int iD_Pais { get; set; }
        #nullable enable
        public string? nombre_Pais { get; set; }
        #nullable disable
        public virtual ICollection<Ciudades> Ciudades { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }



    }
}
