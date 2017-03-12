using System.Collections.Generic;
using MediaLibrary.ViewModels;

namespace MediaLibrary.Models
{
    public class Folder : FolderDetails
    {
        public virtual ICollection<Folder> Children { get; set; }
        public virtual Folder Parent { get; set; }
    }
}
