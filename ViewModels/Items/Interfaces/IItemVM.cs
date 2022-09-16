using FileManager.Models.FileSystemItems.Interfaces;

namespace FileManager.ViewModels.Items.Interfaces;

public interface IItemVM
{
    public IItem Item { get; init; }
    public string IconSource { get; }
}
