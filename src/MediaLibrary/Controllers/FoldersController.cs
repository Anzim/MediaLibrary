using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaLibrary.Models;
using MediaLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Controllers
{
    [Route("[controller]")]
    public class FoldersController : Controller
    {
        protected MediaLibraryContext Context { get; private set; }
        protected IQueryable<Folder> Folders { get; set; }
        public FoldersController(MediaLibraryContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Context = context;
            Folders = Context.Folders.AsNoTracking();
        }

        

        // GET /folders
        [HttpGet]
        public async Task<IList<FolderInfo>> GetList()
        {
            var result = await Folders
                .Where(f => f.ParentId == 0 && f.Privacy == "public")
                .OrderBy(f => f.FolderName)
                .Select(f => new FolderInfo { FolderId = f.FolderId, FolderName = f.FolderName, IsCategory = f.IsCategory})
                .ToListAsync();

            return result;
        }

        // GET /folders/details
        [HttpGet("details")]
        public async Task<IList<FolderDetails>> GetListWithDetails()
        {
            var result = await Folders
                .Where(f => f.ParentId == 0 && f.Privacy == "public")
                .OrderBy(f => f.FolderName)
                .ToListAsync();

            return result.Select(f =>
            {
                var r = new FolderDetails();
                r.CopyFrom(f);
                return r;
            }).ToList();
        }

        // GET /folders/5
        [HttpGet("{id}")]
        public async Task<FolderDetails> GetDetails(int id)
        {
            var folder = await Folders
                .FirstOrDefaultAsync(f => f.FolderId == id);
	    
	    var result = new FolderDetails();
            result.CopyFrom(folder);	
	
            return result;
        }

        // GET /folders/5/children
        [HttpGet("{id}/children")]
        public async Task<IList<FolderInfo>> GetChildren(int id)
        {
            var result = await Folders
                .Where(f => f.ParentId == id && f.Privacy == "public")
                .Select(ci => new FolderInfo { FolderId = ci.FolderId, FolderName = ci.FolderName, IsCategory = ci.IsCategory } )
                .OrderBy(f => f.FolderName)
                .ToListAsync();
            
            return result;
            //return Folders.OrderBy(f => f.FolderName).Include(f => new f.Children).FirstOrDefault(f => f.FolderId == id);
        }

        // GET /folders/5/children
        [HttpGet("{id}/tracks")]
        public async Task<IList<Track>> GetTracks(int id)
        {
            var result = await Context.Tracks
                .Where(f => f.FolderId == id && f.Privacy == "public")
                //.Select(ci => new FolderInfo { FolderId = ci.FolderId, FolderName = ci.FolderName, IsCategory = ci.IsCategory })
                //.OrderBy(f => f.Album)
                //.ThenBy(f => f.TrackId)
                .ToListAsync();

            return result;
        }

        // POST /folders
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // PUT /folders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // DELETE /folders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(501);
        }
    }
}
