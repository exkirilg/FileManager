using FileManager.FileSystem;
using System.ComponentModel;

namespace FileManager.ViewModels;

public class ApplicationViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private IFileSystemServices _fileSystemServices;

    public ApplicationViewModel(IFileSystemServices fileSystemServices)
    {
        _fileSystemServices = fileSystemServices;
    }
}
