using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class NoticiasUsuarioView
    {
        public string Name { get; set; }
        public string NombreUsuario { get; set; }
        public int Noticias { get; set; }
        public string Noticias_Titulo { get; set; }
        public string Noticias_Texto { get; set; }
        public List <Noticias> Noticia { get; set; }
    }
}
