using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Perfiles
    {
        public int iD_Perfil { get; set; }
        public string tipo_Perfil { get; set; }

        public virtual ICollection<Usuarios>Usuarios { get; set; }
    }
}
