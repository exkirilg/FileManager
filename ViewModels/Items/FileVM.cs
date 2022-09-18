using System;
using System.Threading.Tasks;
using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.ViewModels.Items.Abstract;

namespace FileManager.ViewModels.Items;

public class FileVM : AbstractItemVM
{
    public override string IconSource
    {
        get
        {
            if (Item is File file)
            {
                return file.Extension switch
                {
                    ".exe" => $"{IconSourceBase}exe-file.ico",
                    ".txt" or ".json" => $"{IconSourceBase}text-file.ico",
                    _ => $"{IconSourceBase}file.ico",
                };
            }

            throw new Exception($"Item is of invalid type");
        }
    }

    public FileVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, fullPath, (fullPath, fsServices) =>
        {
            var (fullName, name, extension) = fsServices.GetBasicFileInfo(fullPath);
            return new File(fullName, name, extension);
        })
    {
    }

    public override void Expand(AppVM appVM)
    {
        _fsServices.TryExecuteFile(Item.FullPath);
    }

    protected override async Task LoadInfoAsync()
    {
        Info = await _fsServices.GetFileInfoAsync(Item.FullPath);
    }
}
