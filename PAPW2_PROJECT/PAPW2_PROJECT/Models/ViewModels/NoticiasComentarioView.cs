using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class NoticiasComentarioView
    {
        public string Noticia_Titulo { get; set; }
        List<Comentarios> Comentarios { get; set; }
    }
}
