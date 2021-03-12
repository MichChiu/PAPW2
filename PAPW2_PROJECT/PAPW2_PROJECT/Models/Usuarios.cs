using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Usuarios
    {
        public int iD_Usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public byte[] pp { get; set; }
        public string correoE { get; set; }
        public string contraseña { get; set; }
        public string nombreUsuario { get; set; }
        public string telefono { get; set; }
        public int perfil { get; set; }

        public virtual Perfiles Perfiles { get; set; }
}
}
