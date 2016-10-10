using System.Collections.Generic;

namespace MediaLibrary.ViewModels
{
    public class FolderDetailsWithChildrenInfo : FolderDetails
    {
        //public FolderDetailsWithChildrenInfo()
        //{
        //}

        //public FolderDetailsWithChildrenInfo(FolderDetails folderDetails)
        //{
        //    var type = typeof(T);
        //    foreach (var sourceProperty in type.GetProperties())
        //    {
        //        var targetProperty = type.GetProperty(sourceProperty.Name);
        //        targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
        //    }
        //}
        public virtual ICollection<FolderInfo> ChildrenInfo { get; set; }
    }
}