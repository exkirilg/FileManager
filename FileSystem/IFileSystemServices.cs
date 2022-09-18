using System.Collections.Generic;
using System.IO;

namespace FileManager.FileSystem;

public interface IFileSystemServices
{
    IEnumerable<string> TryGetDrives();
    IEnumerable<string> TryGetFolders(string path);
    IEnumerable<string> TryGetFiles(string path);
    void TryExecuteFile(string fileName);
    Models.FileSystemItemsInformation.DriveInfo GetDriveInfo(string driveName);
    Models.FileSystemItemsInformation.FolderInfo GetFolderInfo(string path);
    Models.FileSystemItemsInformation.FileInfo GetFileInfo(string fileName);
}
