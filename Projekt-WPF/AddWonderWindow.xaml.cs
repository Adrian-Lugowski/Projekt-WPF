using Projekt_WPF.Models;
using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class AddWonderWindow : Window
    {
        public AddWonderWindow(Wonder? wonderToEdit = null)
        {
            InitializeComponent();

            var vm = new AddWonderViewModel(wonderToEdit);

            vm.CloseAction = () => this.Close();

            this.DataContext = vm;
        }
    }
}