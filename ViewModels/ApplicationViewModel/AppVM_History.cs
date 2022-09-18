using FileManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FileManager.ViewModels;

public partial class AppVM
{
    private HistoryWindow? _historyWindow;

    public ObservableCollection<FileAccessRecord> FileAccessHistory
    {
        get => new(_dbContext.FilesAccessRecords);
    }

    public RelayCommand HistoryCommand { get; private set; }
    public RelayCommand CloseHistoryCommand { get; private set; }

    private void InitializeHistoryCommands()
    {
        HistoryCommand = new RelayCommand(obj =>
        {
            if (_historyWindow is not null)
            {
                _historyWindow.Close();
                _historyWindow = null;
            }
            else
            {
                _historyWindow = new HistoryWindow(this);
                _historyWindow.Show();
            }
        });

        CloseHistoryCommand = new RelayCommand(obj =>
        {
            if (_historyWindow is not null)
            {
                _historyWindow.Close();
                _historyWindow = null;
            }
        });
    }

    private async Task SaveFileAccess(string fileName, DateTime accessDateTime)
    {
        await _dbContext.FilesAccessRecords.AddAsync(
            new FileAccessRecord() { FileName = fileName, AccessDateTime = accessDateTime });
        await _dbContext.SaveChangesAsync();

        OnPropertyChanged(nameof(FileAccessHistory));
    }
}
