using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPW2_PROJECT.Models.ViewModels
{
    public class ResponseApiError: ResponseApiSuccess
    {
        public int HttpStatusCode { get; set; }
    }
}
