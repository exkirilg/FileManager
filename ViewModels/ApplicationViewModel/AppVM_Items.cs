using FileManager.ViewModels.Items;
using FileManager.ViewModels.Items.Interfaces;
using System.Collections.ObjectModel;

namespace FileManager.ViewModels;

public partial class AppVM
{
    private IItemVM? _selectedItem;

    public ObservableCollection<IItemVM> Items { get; init; } = new();
    public IItemVM? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }

    public RelayCommand SelectItem { get; private set; }
    public RelayCommand ExpandItem { get; private set; }

    private void InitializeItemsCommands()
    {
        SelectItem = new RelayCommand(obj =>
        {
            SelectedItem = obj as IItemVM;
        });

        ExpandItem = new RelayCommand(obj =>
        {
            SelectedItem = obj as IItemVM;
            SelectedItem?.Expand(this);
        });
    }

    private void PopulateItemsWithDrives()
    {
        foreach (var driveName in _fsServices.TryGetDrives())
        {
            Items.Add(new DriveVM(_fsServices, driveName));
        }
    }

    private void PopulateItems()
    {
        foreach (var folderPath in _fsServices.TryGetFolders(CurrentPath))
        {
            Items.Add(new FolderVM(_fsServices, folderPath));
        }

        foreach (var filePath in _fsServices.TryGetFiles(CurrentPath))
        {
            Items.Add(new FileVM(_fsServices, filePath));
        }
    }
}
