using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.ViewModels.Items.Abstract;
using System.Threading.Tasks;

namespace FileManager.ViewModels.Items;

public class FolderVM : AbstractItemVM
{
    public override string IconSource => $"{IconSourceBase}folder.ico";

    public FolderVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, fullPath, (fullPath, fsServices) =>
        {
            var (fullName, name) = fsServices.GetBasicFolderInfo(fullPath);
            return new Folder(fullName, name);
        })
    {
    }

    public override void Expand(AppVM appVM)
    {
        appVM.CurrentPath = Item.FullPath;
    }

    protected override async Task LoadInfoAsync()
    {
        Info = await _fsServices.GetFolderInfoAsync(Item.FullPath);
    }
}
