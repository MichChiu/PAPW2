using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class NoticiasComentarioView
    {
        public int Noticias { get; set; }
        public string Noticias_Titulo { get; set; }
        public string Noticias_Texto { get; set; }
        public string Comentario { get; set; }
        List<Comentarios> Comentarios { get; set; }
    }
}
