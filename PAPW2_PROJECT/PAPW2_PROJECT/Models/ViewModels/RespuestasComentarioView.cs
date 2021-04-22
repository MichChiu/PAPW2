using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class RespuestasComentarioView
    {
        public string Comentario { get; set; }
        public string Respuesta { get; set; }
        List<Respuestas> Respuestas { get; set; }
    }
}
