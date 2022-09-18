using FileManager.FileSystem;
using FileManager.Models.FileSystemItems.Interfaces;
using FileManager.Models.FileSystemItemsInformation.Interfaces;
using FileManager.ViewModels.Items.Interfaces;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FileManager.ViewModels.Items.Abstract;

public abstract class AbstractItemVM : IItemVM, INotifyPropertyChanged
{
    protected readonly IFileSystemServices _fsServices;
    protected string IconSourceBase = "pack://application:,,,/Icons/";
    protected IInfo? _info;

    public IItem Item { get; init; }
    abstract public string IconSource { get; }

    public IInfo? Info
    {
        get
        {
            if (_info is null)
            {
                Task.Run(async () => await LoadInfoAsync());
                return null;
            }

            return _info;
        }
        set
        {
            _info = value;
            OnPropertyChanged(nameof(Info));
        }
    }

    protected AbstractItemVM(IFileSystemServices fsServices, IItem item)
	{
        _fsServices = fsServices;
        Item = item;
	}
    protected AbstractItemVM(IFileSystemServices fsServices, string fullPath, Func<string, IFileSystemServices, IItem> itemFunction)
        : this(fsServices, itemFunction.Invoke(fullPath, fsServices))
    {
    }

    public abstract void Expand(AppVM appVM);

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected abstract Task LoadInfoAsync();
}
