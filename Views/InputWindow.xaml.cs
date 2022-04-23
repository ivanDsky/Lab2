using System.Windows;
using System.Windows.Controls;
using Lab2.ViewModels;

namespace Lab2.Views
{
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            DataContext = new InfoWindowViewModel();
        }
    }
}