using Microsoft.EntityFrameworkCore;
using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Wonder> Wonders { get; set; } = new ObservableCollection<Wonder>();

        public ICommand LoadDataCommand { get; }
        public ICommand OpenAddWindowCommand { get; }

        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand(LoadData);
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);

            LoadData(null);
        }

        private void LoadData(object? parameter)
        {
            using (var context = new AppDbContext())
            {
                var list = context.Wonders.ToList();

                Wonders.Clear();
                foreach (var item in list)
                {
                    Wonders.Add(item);
                }
            }
        }

        private void OpenAddWindow(object? parameter)
        {
            var addWindow = new AddWonderWindow();

            addWindow.ShowDialog();

            LoadData(null);
        }
    }
}