using FileManager.Models.FileSystemItems.Interfaces;

namespace FileManager.Models.FileSystemItems;

public class Drive : IItem
{
    public TypeOfFileSystemItem Type => TypeOfFileSystemItem.Drive;
    public string FullPath { get; init; }
    public string Name { get; init; }

    public Drive(string fullPath, string name)
    {
        FullPath = fullPath;
        Name = name;
    }
}
