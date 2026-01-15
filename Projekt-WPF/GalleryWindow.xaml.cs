using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class GalleryWindow : Window
    {
        public GalleryWindow()
        {
            InitializeComponent();

            // Tworzymy ViewModel i przypisujemy go jako kontekst danych
            var vm = new GalleryViewModel();

            // Obsługa zamknięcia okna przez ViewModel
            vm.CloseAction = () => this.Close();

            this.DataContext = vm;
        }
    }
}