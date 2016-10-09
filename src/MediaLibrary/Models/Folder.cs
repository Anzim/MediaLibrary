using System;
using System.Collections.Generic;

namespace MediaLibrary.Models
{
    public partial class Folder
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public int ParentId { get; set; }
        public string Privacy { get; set; }
        public bool Downloadable { get; set; }
        public string ZipFile { get; set; }
        public bool HasMp3 { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsCategory { get; set; }
    }
}
