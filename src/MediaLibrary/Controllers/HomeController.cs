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
            return "usage: http://api.propovednik.com/folders, /folders/1, /folders/1/children, /folders/14540/tracks, /tracks/253139";
        }


    }
}
