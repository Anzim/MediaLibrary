using System;
using System.Collections.Generic;
using MediaLibrary.ViewModels;

namespace MediaLibrary.Models
{
    public partial class Folder : FolderDetails
    {
        public virtual ICollection<Folder> Children { get; set; }
        public virtual Folder Parent { get; set; }
    }
}
