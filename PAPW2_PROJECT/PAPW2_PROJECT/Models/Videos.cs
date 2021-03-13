using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models
{
    public class Videos
    {
        public int iD_Video { get; set; }

        public int iD_Noticia { get; set; }

        public string video_URL { get; set; }

        public virtual Noticias Noticias { get; set; }
    }
}
