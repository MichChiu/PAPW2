using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class NoticiasUsuarioView
    {
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        List <Noticias> Noticia { get; set; }
    }
}
