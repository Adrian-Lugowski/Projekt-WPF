using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Projekt_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Wonder> Wonders { get; set; } = new ObservableCollection<Wonder>();

        private Wonder? _selectedWonder;
        public Wonder? SelectedWonder
        {
            get => _selectedWonder;
            set
            {
                SetProperty(ref _selectedWonder, value);
                (EditCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand LoadDataCommand { get; }
        public ICommand OpenAddWindowCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public Action? CloseAction { get; set; }
        public ICommand NavigateBackCommand { get; }

        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand(LoadData);
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            EditCommand = new RelayCommand(EditWonder, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteWonder, CanEditOrDelete);
            NavigateBackCommand = new RelayCommand(NavigateBack);

            LoadData(null);
        }

        private bool CanEditOrDelete(object? parameter)
        {
            return SelectedWonder != null;
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
            var addWindow = new AddWonderWindow(null);
            addWindow.ShowDialog();
            LoadData(null);
        }

        private void EditWonder(object? parameter)
        {
            if (SelectedWonder == null) return;

            var editWindow = new AddWonderWindow(SelectedWonder);
            editWindow.ShowDialog();
            LoadData(null);
        }

        private void DeleteWonder(object? parameter)
        {
            if (SelectedWonder == null) return;

            var result = MessageBox.Show($"Czy na pewno chcesz usunąć: {SelectedWonder.Name}?",
                                         "Potwierdzenie",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var context = new AppDbContext())
                {
                    context.Wonders.Remove(SelectedWonder);
                    context.SaveChanges();
                }
                LoadData(null);
            }
        }

        private void NavigateBack(object? parameter)
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();

            CloseAction?.Invoke();
        }
    }

    public static class RelayCommandExtensions
    {
        public static void RaiseCanExecuteChanged(this RelayCommand command)
        {
        }
    }
}