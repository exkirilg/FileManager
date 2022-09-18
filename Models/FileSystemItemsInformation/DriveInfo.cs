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

    public string CapacityToString => $"{Capacity:N0} bytes";
    public string UsedSpaceToString => $"{UsedSpace:N0} bytes";
    public string FreeSpaceToString => $"{FreeSpace:N0} bytes";

    public string CapacityInGBToString => $"{Math.Round(Capacity / 1024d / 1024d / 1024d, 2):N0} GB";
    public string UsedSpaceInGBToString => $"{Math.Round(UsedSpace / 1024d / 1024d / 1024d, 2):N0} GB";
    public string FreeSpaceInGBToString => $"{Math.Round(FreeSpace / 1024d / 1024d/ 1024d, 2):N0} GB";

    public DriveInfo(string name, string fileSystem, long capacity, long usedSpace, long freeSpace)
    {
        Name = name;
        FileSystem = fileSystem;

        Capacity = capacity;
        UsedSpace = usedSpace;
        FreeSpace = freeSpace;
    }
}
