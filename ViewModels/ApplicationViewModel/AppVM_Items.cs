using FileManager.ViewModels.Items;
using FileManager.ViewModels.Items.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileManager.ViewModels;

public partial class AppVM
{
    private ObservableCollection<IItemVM> _items = new();
    private IItemVM? _selectedItem;
    private string? _search;

    public ObservableCollection<IItemVM> Items
    {
        get
        {
            return new (_items.Where(i => string.IsNullOrEmpty(Search) || i.Item.Name.Contains(Search, System.StringComparison.CurrentCultureIgnoreCase)));
        }
    }
    public IItemVM? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
    public string? Search
    {
        get => _search;
        set
        {
            _search = value;

            SelectedItem = null;

            OnPropertyChanged(nameof(Search));
            OnPropertyChanged(nameof(Items));
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
            _items.Add(new DriveVM(_fsServices, driveName));
        }
    }

    private void PopulateItems()
    {
        foreach (var folderPath in _fsServices.TryGetFolders(CurrentPath))
        {
            _items.Add(new FolderVM(_fsServices, folderPath));
        }

        foreach (var filePath in _fsServices.TryGetFiles(CurrentPath))
        {
            _items.Add(new FileVM(_fsServices, filePath));
        }
    }
}
