using System.Windows;
using System.Windows.Controls;
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

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.OnDataChanged(datePicker.SelectedDate);
        }
    }
}