using FileManager.FileSystem;
using System.ComponentModel;

namespace FileManager.ViewModels;

public partial class AppVM : INotifyPropertyChanged
{
    private readonly IFileSystemServices _fsServices;

    public AppVM(IFileSystemServices fileSystemServices)
    {
        _fsServices = fileSystemServices;

        CurrentPath = string.Empty;

        InitializeCurrentPathCommands();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
