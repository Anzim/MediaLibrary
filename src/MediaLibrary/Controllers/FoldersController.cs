using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaLibrary.Models;
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
            Context = context;
            Folders = Context.Folders;
        }

        

        // GET api/folders
        [HttpGet]
        public IEnumerable<Folder> Get()
        {
            return Folders.Where(f => f.ParentId == 0).ToList();
        }

        // GET api/folders/5
        [HttpGet("{id}")]
        public Folder Get(int id)
        {
            return Context.Folders.OrderBy(f => f.FolderName).Include(f => f.Children).FirstOrDefault(f => f.FolderId == id);
        }

        // POST api/folders
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/folders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/folders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
