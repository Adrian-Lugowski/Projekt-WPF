using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Projekt_WPF.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        private readonly List<Wonder> _wonders = new List<Wonder>();
        private int _currentIndex = 0;

        private Wonder? _currentWonder;
        public Wonder? CurrentWonder
        {
            get => _currentWonder;
            set => SetProperty(ref _currentWonder, value);
        }

        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand CloseCommand { get; }
        public Action? CloseAction { get; set; }

        public GalleryViewModel()
        {
            LoadData();

            NextCommand = new RelayCommand(_ => MoveNext());
            PreviousCommand = new RelayCommand(_ => MovePrevious());
            CloseCommand = new RelayCommand(_ => CloseAction?.Invoke());
        }

        private void LoadData()
        {
            using (var context = new AppDbContext())
            {
                var list = context.Wonders.ToList();
                _wonders.AddRange(list);
            }

            if (_wonders.Any())
            {
                CurrentWonder = _wonders[0];
            }
        }

        private void MoveNext()
        {
            if (!_wonders.Any()) return;

            _currentIndex++;
            if (_currentIndex >= _wonders.Count)
            {
                _currentIndex = 0;
            }
            CurrentWonder = _wonders[_currentIndex];
        }

        private void MovePrevious()
        {
            if (!_wonders.Any()) return;

            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _wonders.Count - 1;
            }
            CurrentWonder = _wonders[_currentIndex];
        }
    }
}