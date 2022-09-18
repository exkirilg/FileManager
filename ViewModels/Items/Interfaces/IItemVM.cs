using FileManager.Models.FileSystemItems.Interfaces;
using FileManager.Models.FileSystemItemsInformation.Interfaces;

namespace FileManager.ViewModels.Items.Interfaces;

public interface IItemVM
{
    IItem Item { get; }
    string IconSource { get; }

    bool IsDrive { get; }
    bool IsFolder { get; }
    bool IsFile { get; }

    IInfo Info { get; }

    void Expand(AppVM appVM);
}
