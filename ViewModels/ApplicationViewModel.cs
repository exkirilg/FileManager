using FileManager.FileSystem;
using System.ComponentModel;

namespace FileManager.ViewModels;

public partial class ApplicationViewModel : INotifyPropertyChanged
{
    private readonly IFileSystemServices _fileSystemServices;

    public ApplicationViewModel(IFileSystemServices fileSystemServices)
    {
        _fileSystemServices = fileSystemServices;

        CurrentPath = string.Empty;

        InitializeCurrentPathCommands();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
