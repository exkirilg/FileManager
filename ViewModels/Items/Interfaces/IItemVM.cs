using FileManager.Models.FileSystemItems.Interfaces;
using FileManager.Models.FileSystemItemsInformation.Interfaces;
using System.ComponentModel;

namespace FileManager.ViewModels.Items.Interfaces;

public interface IItemVM
{
    IItem Item { get; }
    string IconSource { get; }
    IInfo? Info { get; }

    void Expand(AppVM appVM);

    event PropertyChangedEventHandler? PropertyChanged;
}
