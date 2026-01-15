using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Windows;
using System.Windows.Input;

namespace Projekt_WPF.ViewModels
{
    public class AddWonderViewModel : ViewModelBase
    {
        private Wonder _newWonder = new Wonder();
        public Wonder NewWonder
        {
            get => _newWonder;
            set => SetProperty(ref _newWonder, value);
        }

        public ICommand SaveCommand { get; }

        public Action? CloseAction { get; set; }

        public AddWonderViewModel()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(NewWonder.Name))
            {
                MessageBox.Show("Podaj nazwę obiektu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new AppDbContext())
            {
                context.Wonders.Add(NewWonder);
                context.SaveChanges();
            }

            MessageBox.Show("Dodano pomyślnie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            CloseAction?.Invoke();
        }
    }
}