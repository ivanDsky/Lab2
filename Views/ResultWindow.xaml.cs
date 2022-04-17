using System.Windows;
using Lab2.Models;
using Lab2.ViewModels;

namespace Lab2.Views
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(Person person)
        {
            InitializeComponent();
            DataContext = new ResultWindowViewModel(person);
        }
    }
}