using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class UsuariosPerfilView
    {
        public string Name { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Perfil { get; set; }

        public string CompleteInfo { get; set; }
        public List<Perfiles> Perfiles { get; set; }

    }
}
