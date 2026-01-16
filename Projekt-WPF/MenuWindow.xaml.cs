using System.Windows;

namespace Projekt_WPF
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void OpenView_Click(object sender, RoutedEventArgs e)
        {
            GalleryWindow gallery = new GalleryWindow();
            gallery.Show();
        }

        private void OpenManage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow managementWindow = new MainWindow();
            managementWindow.Show();

            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}