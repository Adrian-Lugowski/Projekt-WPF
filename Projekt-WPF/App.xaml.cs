using System.Windows;
using Projekt_WPF.Data;

namespace Projekt_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}