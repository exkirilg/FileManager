using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.Models.FileSystemItemsInformation.Interfaces;
using FileManager.ViewModels.Items.Abstract;

namespace FileManager.ViewModels.Items;

public class FolderVM : AbstractItemVM
{
    public override string IconSource => $"{IconSourceBase}folder.ico";

    public override bool IsDrive => false;
    public override bool IsFolder => true;
    public override bool IsFile => false;

    public override IInfo Info => _fsServices.GetFolderInfo(Item.FullPath);

    public FolderVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, fullPath, (fullPath, fsServices) =>
        {
            var folderInfo = fsServices.GetFolderInfo(fullPath);
            return new Folder(fullPath, folderInfo.Name);
        })
    {
    }

    public override void Expand(AppVM appVM)
    {
        appVM.CurrentPath = Item.FullPath;
    }
}
