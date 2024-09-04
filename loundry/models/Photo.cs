using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace swagger_loundry.models
{
    public class Photo
    {
        public IFormFile files { get; set; }
    }
}
