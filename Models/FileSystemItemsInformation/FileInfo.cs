using FileManager.Models.FileSystemItemsInformation.Interfaces;
using System;

namespace FileManager.Models.FileSystemItemsInformation;

public class FileInfo : IInfo
{
    public string Name { get; init; }
    public string Location { get; init; }
    public string Extension { get; init; }

    public DateTime CreationTime { get; init; }
    public DateTime LastModified { get; init; }
    public DateTime LastAccessed { get; init; }

    public long Size { get; init; }

    public string SizeToString => $"{Size:N0} bytes";
    public string SizeInMBToString => $"{Math.Round(Size / 1024d / 1024d, 2):N0} MB";

    public FileInfo(string name, string location, string extension, DateTime creationTime, DateTime lastModified, DateTime lastAccessed, long size)
    {
        Name = name;
        Location = location;
        Extension = extension;
        CreationTime = creationTime;
        LastModified = lastModified;
        LastAccessed = lastAccessed;
        Size = size;
    }
}
