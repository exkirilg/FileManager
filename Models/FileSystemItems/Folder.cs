using FileManager.Models.FileSystemItems.Interfaces;

namespace FileManager.Models.FileSystemItems;

public class Folder : IItem
{
    public TypeOfFileSystemItem Type => TypeOfFileSystemItem.Folder;
    public string FullPath { get; init; }
    public string Name { get; init; }

    public Folder(string fullPath, string name)
    {
        FullPath = fullPath;
        Name = name;
    }
}
