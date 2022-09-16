using System.Collections.Generic;
using System.IO;

namespace FileManager.FileSystem;

public interface IFileSystemServices
{
    IEnumerable<string> GetDrives();
    IEnumerable<string> GetFolders(string path);
    IEnumerable<string> GetFiles(string path);
    DirectoryInfo GetFolderInfo(string path);
    FileInfo GetFileInfo(string fileName);
}
