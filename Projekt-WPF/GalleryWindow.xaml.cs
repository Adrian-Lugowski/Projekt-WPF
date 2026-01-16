using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class GalleryWindow : Window
    {
        public GalleryWindow()
        {
            InitializeComponent();
            var vm = new GalleryViewModel();
            vm.CloseAction = () => this.Close(); 
            this.DataContext = vm;
        }
    }
}
