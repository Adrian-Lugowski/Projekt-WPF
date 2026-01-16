using Projekt_WPF.Data;
using Projekt_WPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Projekt_WPF.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        public ObservableCollection<Wonder> Wonders { get; set; } = new ObservableCollection<Wonder>();

        private ICollectionView _wondersView;

        private string _filterYear;
        public string FilterYear
        {
            get => _filterYear;
            set
            {
                SetProperty(ref _filterYear, value);
                _wondersView.Refresh();
            }
        }

        public GalleryViewModel()
        {
            LoadData();

            _wondersView = CollectionViewSource.GetDefaultView(Wonders);
            _wondersView.Filter = FilterWonders;
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

        private bool FilterWonders(object item)
        {
            if (string.IsNullOrWhiteSpace(FilterYear)) return true;

            if (item is Wonder wonder && int.TryParse(FilterYear, out int yearLimit))
            {
                return wonder.DateBuilt.Year >= yearLimit;
            }
            return true;
        }
    }
}