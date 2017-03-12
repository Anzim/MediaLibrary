namespace MediaLibrary.ViewModels
{
    public class FolderInfo : Asset
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public bool IsCategory { get; set; }

        //public virtual ICollection<ForderInfo> Children { get; set; }

    }
}
