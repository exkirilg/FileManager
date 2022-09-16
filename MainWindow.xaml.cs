using FileManager.ViewModels;
using System.Windows;

namespace FileManager;

public partial class MainWindow : Window
{
    public MainWindow(ApplicationViewModel applicationViewModel)
    {
        InitializeComponent();
        DataContext = applicationViewModel;
    }
}
