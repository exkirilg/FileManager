using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.FileSystem;

public interface IFileSystemServices
{
    IEnumerable<string> TryGetDrives();
    IEnumerable<string> TryGetFolders(string path);
    IEnumerable<string> TryGetFiles(string path);
    (string fullPath, string name) GetBasicFolderInfo(string path);
    (string fullPath, string name, string extension) GetBasicFileInfo(string fileName);
    void TryExecuteFile(string fileName);
    Task<Models.FileSystemItemsInformation.DriveInfo> GetDriveInfoAsync(string driveName);
    Task<Models.FileSystemItemsInformation.FolderInfo> GetFolderInfoAsync(string path);
    Task<Models.FileSystemItemsInformation.FileInfo> GetFileInfoAsync(string fileName);
}
