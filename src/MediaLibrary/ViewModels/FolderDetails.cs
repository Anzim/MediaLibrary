using System;
using MediaLibrary.Models;

namespace MediaLibrary.ViewModels
{
    public class FolderDetails : Asset
    {
        //public FolderDetails(Folder folder)
        //{
        //    CopyFrom(folder);
        //}
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
