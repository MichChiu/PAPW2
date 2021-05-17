using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class CreateUserRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int perfil { get; set; }
        public virtual Perfiles Perfiles { get; set; }

    }
}
