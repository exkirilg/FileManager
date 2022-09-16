using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.ViewModels.Items.Abstract;

namespace FileManager.ViewModels.Items;

public class FolderVM : AbstractItemVM
{
    public override string IconSource => $"{IconSourceBase}folder.ico";

    public FolderVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, fullPath, (fullPath, fsServices) =>
        {
            var folderInfo = fsServices.GetFolderInfo(fullPath);
            return new Folder(folderInfo.FullName, folderInfo.Name);
        })
    {
    }
}
