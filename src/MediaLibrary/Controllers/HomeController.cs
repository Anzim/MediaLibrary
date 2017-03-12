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
            return "use http://api.propovednik.com/folders, /folders/1, /folders/1/children, /folders/1/tracks, /tracks/1";
        }


    }
}
