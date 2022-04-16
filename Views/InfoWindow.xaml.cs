using System.Windows;
using Lab2.ViewModels;

namespace Lab2.Views
{
    public partial class InfoWindow : Window
    {
        private InfoWindowViewModel _viewModel;
        public InfoWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new InfoWindowViewModel();
        }
    }
}