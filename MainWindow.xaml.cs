using FileManager.ViewModels;
using System.Windows;

namespace FileManager;

public partial class MainWindow : Window
{
    public MainWindow(AppVM applicationViewModel)
    {
        InitializeComponent();
        DataContext = applicationViewModel;
        WindowState = WindowState.Maximized;
    }
}
