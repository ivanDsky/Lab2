using System.Windows;
using System.Windows.Controls;
using Lab2.ViewModels;

namespace Lab2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }
    }
}