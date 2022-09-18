using FileManager.FileSystem;
using System.ComponentModel;

namespace FileManager.ViewModels;

public partial class AppVM : INotifyPropertyChanged
{
    private readonly IFileSystemServices _fsServices;
    private readonly ApplicationContext _dbContext;

    public AppVM(IFileSystemServices fileSystemServices, ApplicationContext dbContext)
    {
        _fsServices = fileSystemServices;
        _dbContext = dbContext;

        CurrentPath = string.Empty;

        InitializeCurrentPathCommands();
        InitializeItemsCommands();
        InitializeHistoryCommands();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
