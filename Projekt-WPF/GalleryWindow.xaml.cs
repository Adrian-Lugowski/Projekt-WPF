using Projekt_WPF.ViewModels;
using System.Windows;

namespace Projekt_WPF
{
    public partial class GalleryWindow : Window
    {
        public GalleryWindow()
        {
            InitializeComponent();
            this.DataContext = new GalleryViewModel();
        }
    }
}
