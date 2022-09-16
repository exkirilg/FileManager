using FileManager.Models.FileSystemItems.Interfaces;

namespace FileManager.Models.FileSystemItems;

public class File : IItem
{
    public string FullPath { get; init; }
    public string Name { get; init; }
    public string Extension { get; init; }

    public File(string fullPath, string name, string extension)
    {
        FullPath = fullPath;
        Name = name;
        Extension = extension;
    }
}
