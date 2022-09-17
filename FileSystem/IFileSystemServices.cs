using System.Collections.Generic;
using System.IO;

namespace FileManager.FileSystem;

public interface IFileSystemServices
{
    IEnumerable<string> TryGetDrives();
    IEnumerable<string> TryGetFolders(string path);
    IEnumerable<string> TryGetFiles(string path);
    DirectoryInfo GetFolderInfo(string path);
    FileInfo GetFileInfo(string fileName);
    void TryExecuteFile(string fileName);
}
