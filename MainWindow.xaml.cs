using FileManager.ViewModels;
using System.Windows;

namespace FileManager;

public partial class MainWindow : Window
{
    public MainWindow(AppVM applicationViewModel)
    {
        InitializeComponent();
        DataContext = applicationViewModel;
        applicationViewModel.CurrentPath = @"D:\\Projects\\FileManager\\bin\\Debug\\net6.0-windows";
    }
}
