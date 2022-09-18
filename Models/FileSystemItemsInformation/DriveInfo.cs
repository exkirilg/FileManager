using FileManager.Models.FileSystemItemsInformation.Interfaces;
using System;

namespace FileManager.Models.FileSystemItemsInformation;

public class DriveInfo : IInfo
{
    public string Name { get; init; }
    public string FileSystem { get; init; }

    public long Capacity { get; init; }
    public long UsedSpace { get; init; }
    public long FreeSpace { get; init; }

    public DriveInfo(string name, string fileSystem, long capacity, long usedSpace, long freeSpace)
    {
        Name = name;
        FileSystem = fileSystem;

        Capacity = capacity;
        UsedSpace = usedSpace;
        FreeSpace = freeSpace;
    }
}
