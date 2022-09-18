using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileManager.FileSystem;

public class FileSystemServices : IFileSystemServices
{
    public IEnumerable<string> TryGetDrives()
    {
        IEnumerable<string> result = Enumerable.Empty<string>();

        try
        {
            result = Directory.GetLogicalDrives();
        }
        catch { }

        return result;
    }

    public IEnumerable<string> TryGetFolders(string path)
    {
        IEnumerable<string> result = Enumerable.Empty<string>();

        try
        {
            result = Directory.GetDirectories(path);
        }
        catch { }

        return result;
    }

    public IEnumerable<string> TryGetFiles(string path)
    {
        IEnumerable<string> result = Enumerable.Empty<string>();

        try
        {
            result = Directory.GetFiles(path);
        }
        catch { }

        return result;
    }

    public void TryExecuteFile(string fileName)
    {
        try
        {
            new Process { StartInfo = new ProcessStartInfo(fileName) { UseShellExecute = true } }
                .Start();
        }
        catch { }
    }

    public Models.FileSystemItemsInformation.DriveInfo GetDriveInfo(string driveName)
    {
        DriveInfo driveInfo = new(driveName);

        return
            new Models.FileSystemItemsInformation.DriveInfo(
                driveInfo.Name,
                driveInfo.DriveFormat,
                driveInfo.TotalSize,
                driveInfo.TotalSize - driveInfo.AvailableFreeSpace,
                driveInfo.AvailableFreeSpace);
    }

    public Models.FileSystemItemsInformation.FolderInfo GetFolderInfo(string path)
    {
        DirectoryInfo dirInfo = new(path);

        if (dirInfo.Exists == false)
            throw new ArgumentException($"Folder {path} doesn't exist", nameof(path));

        return
            new Models.FileSystemItemsInformation.FolderInfo(
                dirInfo.Name,
                dirInfo.Parent!.FullName,
                dirInfo.CreationTime,
                TryGetFolderSize(dirInfo),
                TryGetAmountOfFilesInFolder(path),
                TryGetAmountOfFoldersInFolder(path));
    }

    public Models.FileSystemItemsInformation.FileInfo GetFileInfo(string fileName)
    {
        FileInfo fileInfo = new(fileName);

        if (fileInfo.Exists == false)
            throw new ArgumentException($"File {fileName} doesn't exist", nameof(fileName));

        return
            new Models.FileSystemItemsInformation.FileInfo(
                fileInfo.Name,
                fileInfo.DirectoryName!,
                fileInfo.Extension,
                fileInfo.CreationTime,
                fileInfo.LastWriteTime,
                fileInfo.LastAccessTime,
                fileInfo.Length);
    }

    private long TryGetFolderSize(DirectoryInfo dirInfo)
    {
        long result = 0;

        foreach (var fileInfo in TryGetFiles(dirInfo.FullName).Select(fileName => new FileInfo(fileName)))
        {
            result += fileInfo.Length;
        }

        foreach (var dir in TryGetFolders(dirInfo.FullName).Select(folderName => new DirectoryInfo(folderName)))
        {
            result += TryGetFolderSize(dir);
        }

        return result;
    }
    private int TryGetAmountOfFilesInFolder(string path)
    {
        int result = 0;

        try
        {
            result += Directory.GetFiles(path, string.Empty, SearchOption.AllDirectories).Length;
        }
        catch { }

        return result;
    }
    private int TryGetAmountOfFoldersInFolder(string path)
    {
        int result = 0;

        try
        {
            result += Directory.GetDirectories(path, string.Empty, SearchOption.AllDirectories).Length;
        }
        catch { }

        return result;
    }

}
