using FileManager.Models.FileSystemItemsInformation.Interfaces;
using System;

namespace FileManager.Models.FileSystemItemsInformation;

public class FolderInfo : IInfo
{
    public string Name { get; init; }
    public string Location { get; init; }
    public DateTime CreationTime { get; init; }
    public long Size { get; init; }
    public int AmountOfFiles { get; init; }
    public int AmountOfFolders { get; init; }

    public string SizeToString => $"{Size:N0} bytes";
    public string SizeInMBToString => $"{Math.Round(Size / 1024d / 1024d, 2):N0} MB";
    public string AmountOfFilesToString => $"{AmountOfFiles:N0} files";
    public string AmountOfFoldersToString => $"{AmountOfFolders:N0} Folders";

    public FolderInfo(string name, string location, DateTime creationTime, long size, int amountOfFiles, int amountOfFolders)
    {
        Name = name;
        Location = location;
        CreationTime = creationTime;
        Size = size;
        AmountOfFiles = amountOfFiles;
        AmountOfFolders = amountOfFolders;
    }
}
