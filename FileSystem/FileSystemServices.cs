using FileManager.Models.FileSystemItems.Interfaces;
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

    public DirectoryInfo GetFolderInfo(string path)
    {
        DirectoryInfo dirInfo = new(path);

        if (dirInfo.Exists == false)
            throw new ArgumentException($"Folder {path} doesn't exist", nameof(path));

        return dirInfo;
    }

    public FileInfo GetFileInfo(string fileName)
    {
        FileInfo fileInfo = new(fileName);

        if (fileInfo.Exists == false)
            throw new ArgumentException($"File {fileName} doesn't exist", nameof(fileName));

        return fileInfo;
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
}
