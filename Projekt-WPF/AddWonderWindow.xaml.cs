using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class AddWonderWindow : Window
    {
        public AddWonderWindow()
        {
            InitializeComponent();
            var vm = new AddWonderViewModel();

            vm.CloseAction = () => this.Close();

            this.DataContext = vm;
        }
    }
}