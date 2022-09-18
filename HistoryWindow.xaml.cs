using FileManager.ViewModels;
using System.Windows;

namespace FileManager;

public partial class HistoryWindow : Window
{
    public HistoryWindow(AppVM applicationViewModel)
    {
        InitializeComponent();
        DataContext = applicationViewModel;
    }
}
