using System.Linq;
using System.Threading.Tasks;
using MediaLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Controllers
{
    [Route("[controller]")]
    public class TracksController : Controller
    {
        private static string _baseUrl = "http://propovednik.com/media/mp3/";
        protected MediaLibraryContext Context { get; private set; }
        protected IQueryable<Track> Tracks { get; private set; }
        protected IQueryable<Folder> Folders { get; set; }
        public TracksController(MediaLibraryContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Context = context;
            Tracks = Context.Tracks.AsNoTracking();
            Folders = Context.Folders.AsNoTracking();
        }




        // GET /tracks
        [HttpGet]
        public IActionResult GetList()//async Task<IList<Track>> GetList()
        {
            return new StatusCodeResult(501);
            //var result = await Tracks
            //    .Where(f => f.ParentId == 0 && f.Privacy == "public")
            //    .OrderBy(f => f.FolderName)
            //    .Select(f => new FolderInfo { FolderId = f.FolderId, FolderName = f.FolderName, IsCategory = f.IsCategory })
            //    .ToListAsync();

            //return result;
        }

        // GET /tracks/details
        //[HttpGet("details")]
        //public async Task<IList<FolderDetails>> GetListWithDetails()
        //{
        //    var result = await Tracks
        //        .Where(f => f.ParentId == 0 && f.Privacy == "public")
        //        .OrderBy(f => f.FolderName)
        //        .ToListAsync();

        //    return result.Select(f =>
        //    {
        //        var r = new FolderDetails();
        //        r.CopyFrom(f);
        //        return r;
        //    }).ToList();
        //}

        // GET /tracks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackDetails(int id)
        {
            var track = await Tracks
                .FirstOrDefaultAsync(f => f.TrackId == id);

            if (track == null) return NotFound();
            if (track.Privacy != "public" &&
                (User == null || !User.HasClaim(c => c.Type == "privacy" && c.Type == track.Privacy))) return Forbid();

            track.TrackFile = await GetFolderUrl(track.FolderId) + track.TrackFile;
            return new ObjectResult(track);
        }

        private async Task<string> GetFolderUrl(int folderId)
        {
            if (folderId == 0) return _baseUrl;
            var folder = await Folders.Select(f => new { f.FolderId, f.FolderName, f.ParentId })
                .FirstOrDefaultAsync(f => f.FolderId == folderId);
            var result = await GetFolderUrl(folder.ParentId) + folder.FolderName + "/";
            return result;
        }

        // GET /tracks/5/children
        //[HttpGet("{id}/children")]
        //public async Task<IList<FolderInfo>> GetChildren(int id)
        //{
        //    var result = await Tracks
        //        .Where(f => f.ParentId == id && f.Privacy == "public")
        //        .Select(ci => new FolderInfo { FolderId = ci.FolderId, FolderName = ci.FolderName, IsCategory = ci.IsCategory } )
        //        .OrderBy(f => f.FolderName)
        //        .ToListAsync();
            
        //    return result;
        //    //return tracks.OrderBy(f => f.FolderName).Include(f => new f.Children).FirstOrDefault(f => f.FolderId == id);
        //}

        // POST /tracks
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // PUT /tracks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // DELETE /tracks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(501);
        }
    }
}
