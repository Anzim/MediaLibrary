using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediaLibrary.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET /
        [Route("")]
        [HttpGet]
        public string Get()
        {
            return "It works!";
        }


    }
}
