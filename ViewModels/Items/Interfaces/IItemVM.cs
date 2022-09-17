using FileManager.Models.FileSystemItems.Interfaces;

namespace FileManager.ViewModels.Items.Interfaces;

public interface IItemVM
{
    IItem Item { get; init; }
    string IconSource { get; }

    void Expand(AppVM appVM);
}
