using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.ViewModels.Items.Abstract;
using System.Threading.Tasks;

namespace FileManager.ViewModels.Items;

public class DriveVM : AbstractItemVM
{
    public override string IconSource => $"{IconSourceBase}drive.ico";

    public DriveVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, new Drive(fullPath, fullPath))
    {
    }

    public override void Expand(AppVM appVM)
    {
        appVM.CurrentPath = Item.FullPath;
    }

    protected override async Task LoadInfoAsync()
    {
        Info = await _fsServices.GetDriveInfoAsync(Item.FullPath);
    }
}
