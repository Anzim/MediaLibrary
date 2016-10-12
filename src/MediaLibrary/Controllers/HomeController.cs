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
            return "try http://api.propovednik.com/folders, http://api.propovednik.com/folders/1, http://api.propovednik.com/folders/1/children";
        }


    }
}
