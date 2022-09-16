using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager.FileSystem;

public class FileSystemServices : IFileSystemServices
{
    public IEnumerable<string> GetDrives()
    {
        return Directory.GetLogicalDrives();
    }

    public IEnumerable<string> GetFolders(string path)
    {
        return Directory.GetDirectories(path);
    }

    public IEnumerable<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
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
}
