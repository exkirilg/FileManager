using FileManager.Models;
using System.Collections.ObjectModel;
using System.IO;
using System;
using System.Text;

namespace FileManager.ViewModels;

public partial class ApplicationViewModel
{
    private string _currentPath;

    public string CurrentPath
    {
        get => _currentPath;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                _currentPath = value;
                PartsOfPath.Clear();
            }
            else
            {
                var dirInfo = new DirectoryInfo(value);
                if (dirInfo.Exists == false) throw new ArgumentException($"Directory {value} doesn't exist", nameof(value));

                _currentPath = dirInfo.FullName;
                PartsOfPath.Clear();

                PopulatePartsOfPath(dirInfo.FullName);
            }

            OnPropertyChanged(nameof(CurrentPath));
            OnPropertyChanged(nameof(PartsOfPath));
        }
    }
    public ObservableCollection<PartOfPath> PartsOfPath { get; init; } = new();

    public RelayCommand BackCommand { get; private set; }
    public RelayCommand SetCurrentPathCommand { get; private set; }

    private void InitializeCurrentPathCommands()
    {
        BackCommand = new RelayCommand(obj =>
        {
            if (string.IsNullOrEmpty(CurrentPath)) return;

            if (PartsOfPath.Count < 2)
            {
                CurrentPath = string.Empty;
            }
            else
            {
                CurrentPath = PartsOfPath[PartsOfPath.Count - 2].FullPath;
            }
        });

        SetCurrentPathCommand = new RelayCommand(obj =>
        {
            if (obj is string newPath)
            {
                CurrentPath = newPath;
                return;
            }

            throw new ArgumentException("Invalid parameter", nameof(obj));
        });
    }
    private void PopulatePartsOfPath(string fullPath)
    {
        var splittedPath = fullPath.Split('\\', StringSplitOptions.RemoveEmptyEntries);
        var strBuilder = new StringBuilder();

        for (int i = 0; i < splittedPath.Length; i++)
        {
            strBuilder.Clear();
            for (int j = 0; j <= i; j++)
            {
                strBuilder.Append($"{splittedPath[j]}\\");
            }
            PartsOfPath.Add(new PartOfPath(strBuilder.ToString(), splittedPath[i]));
        }
    }
}
