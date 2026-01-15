using Microsoft.Win32;
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

        public string WindowTitle => NewWonder.Id == 0 ? "Dodaj Cud Świata" : "Edytuj Cud Świata";

        public ICommand SaveCommand { get; }
        public ICommand SelectImageCommand { get; }
        public Action? CloseAction { get; set; }

        public AddWonderViewModel(Wonder? wonderToEdit = null)
        {
            if (wonderToEdit != null)
            {
                NewWonder = new Wonder
                {
                    Id = wonderToEdit.Id,
                    Name = wonderToEdit.Name,
                    Location = wonderToEdit.Location,
                    Description = wonderToEdit.Description,
                    ImagePath = wonderToEdit.ImagePath,
                    DateBuilt = wonderToEdit.DateBuilt
                };
            }

            SaveCommand = new RelayCommand(Save);
            SelectImageCommand = new RelayCommand(SelectImage);
        }

        private void SelectImage(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki obrazów|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Wybierz zdjęcie obiektu"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                NewWonder.ImagePath = openFileDialog.FileName;
                OnPropertyChanged(nameof(NewWonder));
            }
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
                if (NewWonder.Id == 0)
                {
                    context.Wonders.Add(NewWonder);
                }
                else
                {
                    context.Wonders.Update(NewWonder);
                }

                context.SaveChanges();
            }

            MessageBox.Show("Zapisano pomyślnie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseAction?.Invoke();
        }
    }
}