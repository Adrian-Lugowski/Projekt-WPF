using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}