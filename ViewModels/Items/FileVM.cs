using System;
using FileManager.FileSystem;
using FileManager.Models.FileSystemItems;
using FileManager.Models.FileSystemItemsInformation.Interfaces;
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

    public override bool IsDrive => false;
    public override bool IsFolder => false;
    public override bool IsFile => true;

    public override IInfo Info => _fsServices.GetFileInfo(Item.FullPath);

    public FileVM(IFileSystemServices fsServices, string fullPath)
        : base(fsServices, fullPath, (fullPath, fsServices) =>
        {
            var fileInfo = fsServices.GetFileInfo(fullPath);
            return new File(fullPath, fileInfo.Name, fileInfo.Extension);
        })
    {
    }

    public override void Expand(AppVM appVM)
    {
        _fsServices.TryExecuteFile(Item.FullPath);
    }
}
