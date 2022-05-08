using System.Windows;
using System.Windows.Controls;
using Lab2.Models;
using Lab2.Services;
using Lab2.ViewModels;

namespace Lab2.Views
{
    public partial class InfoWindow : Window
    {
        public InfoWindow(Person person, PersonService service)
        {
            InitializeComponent();
            DataContext = new InfoWindowViewModel(person, service);
        }
    }
}