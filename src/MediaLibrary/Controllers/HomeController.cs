using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        // GET /
     
        [HttpGet]
        public string Get()
        {
            return "try http://api.propovednik.com/folders, /folders/1, /folders/1/children, /tracks";
        }


    }
}
