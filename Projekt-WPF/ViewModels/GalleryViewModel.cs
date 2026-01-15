using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt_WPF.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        // Kolekcja, która automatycznie powiadomi widok o zmianach (dodaniu elementów)
        public ObservableCollection<Wonder> Wonders { get; set; } = new ObservableCollection<Wonder>();

        private Wonder? _selectedWonder;
        public Wonder? SelectedWonder
        {
            get => _selectedWonder;
            set
            {
                SetProperty(ref _selectedWonder, value);
                // Tutaj moglibyśmy dodać dodatkową logikę po wybraniu elementu
            }
        }

        public ICommand NavigateBackCommand { get; }
        public Action? CloseAction { get; set; }

        public GalleryViewModel()
        {
            NavigateBackCommand = new RelayCommand(NavigateBack);
            LoadData();
        }

        private void LoadData()
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

        private void NavigateBack(object? parameter)
        {
            // Otwieramy z powrotem menu i zamykamy galerię
            MenuWindow menu = new MenuWindow();
            menu.Show();
            CloseAction?.Invoke();
        }
    }
}