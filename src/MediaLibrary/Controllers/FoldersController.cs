using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediaLibrary.Models;
using MediaLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Controllers
{
    [Route("api/[controller]")]
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

        

        // GET api/folders
        [HttpGet]
        public async Task<IList<FolderInfo>> GetList()
        {
            var result = await Folders
                .Where(f => f.ParentId == 0)
                .OrderBy(f => f.FolderName)
                .Select(f => new FolderInfo { FolderId = f.FolderId, FolderName = f.FolderName, IsCategory = f.IsCategory})
                .ToListAsync();

            return result;
        }

        // GET api/folders/details
        [HttpGet("details")]
        public async Task<IList<FolderDetails>> GetListWithDetails()
        {
            var result = await Folders
                .Where(f => f.ParentId == 0)
                .OrderBy(f => f.FolderName)
                .ToListAsync();

            return result.Select(f =>
            {
                var r = new FolderDetails();
                r.CopyFrom(f);
                return r;
            }).ToList();
        }

        // GET api/folders/5
        [HttpGet("{id}")]
        public async Task<FolderDetails> GetDetails(int id)
        {
            var result = await Folders
                .FirstOrDefaultAsync(f => f.FolderId == id);

            return result;
        }

        // GET api/folders/5/children
        [HttpGet("{id}/children")]
        public async Task<IList<FolderInfo>> GetChildren(int id)
        {
            var result = await Folders
                .Where(f => f.ParentId == id)
                .Select(ci => new FolderInfo { FolderId = ci.FolderId, FolderName = ci.FolderName, IsCategory = ci.IsCategory } )
                .OrderBy(f => f.FolderName)
                .ToListAsync();
            
            return result;
            //var childrenInfo = await Folders
            //    .OrderBy(f => f.FolderName)
            //    .Select(f => new ForderInfo { FolderId = f.FolderId, FolderName = f.FolderName, IsCategory = f.IsCategory })
            //    .ToListAsync();

            //return Folders.OrderBy(f => f.FolderName).Include(f => new f.Children).FirstOrDefault(f => f.FolderId == id);
        }

        // POST api/folders
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // PUT api/folders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new StatusCodeResult(501);
        }

        // DELETE api/folders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(501);
        }
    }
}
