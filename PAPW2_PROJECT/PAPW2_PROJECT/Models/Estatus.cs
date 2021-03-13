using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Estatus
    {
        public int iD_Estatus { get; set; }
        #nullable enable
        public string? nombre_Estatus { get; set; }
        #nullable disable

        public virtual ICollection<Noticias> Noticias { get; set; }

    }
}
