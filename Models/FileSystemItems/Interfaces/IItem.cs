namespace FileManager.Models.FileSystemItems.Interfaces;

public interface IItem
{
    public TypeOfFileSystemItem Type { get; }
    public string FullPath { get; init; }
    public string Name { get; init; }
}
