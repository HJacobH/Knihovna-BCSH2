using BSCH2Knihovna.Classes;
using BSCH2Knihovna.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BSCH2Knihovna.ViewModels
{
    public class KnihaViewModel : INotifyPropertyChanged
    {
        private readonly LibraryRepository _repository;
        private string _searchQuery;
        public ObservableCollection<Kniha> Knihy { get; set; } = new ObservableCollection<Kniha>();
        public ObservableCollection<Sekce> SekceList { get; set; } = new ObservableCollection<Sekce>();

        private Kniha _selectedKniha;
        private Kniha _editingKniha;

        public ICollectionView FilteredKnihy { get; set; }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilteredKnihy.Refresh();
            }
        }

        public Kniha SelectedKniha
        {
            get => _selectedKniha;
            set
            {
                _selectedKniha = value;

                if (_selectedKniha != null)
                {
                    EditingKniha = new Kniha
                    {
                        ISBN = _selectedKniha.ISBN,
                        Nazev = _selectedKniha.Nazev,
                        Autor = _selectedKniha.Autor,
                        RokVydani = _selectedKniha.RokVydani,
                        Zanr = _selectedKniha.Zanr,
                        Nakladatelstvi = _selectedKniha.Nakladatelstvi,
                        SekceId = _selectedKniha.SekceId
                    };
                }
                else
                {
                    EditingKniha = new Kniha();
                }

                OnPropertyChanged(nameof(SelectedKniha));
            }
        }

        public Kniha EditingKniha
        {
            get => _editingKniha;
            set
            {
                _editingKniha = value;
                OnPropertyChanged(nameof(EditingKniha));
            }
        }

        private Sekce _selectedSekce;
        public Sekce SelectedSekce
        {
            get => _selectedSekce;
            set
            {
                _selectedSekce = value;

                if (EditingKniha != null && SelectedSekce != null)
                {
                    EditingKniha.Zanr = SelectedSekce.Kategorie;
                    OnPropertyChanged(nameof(EditingKniha));
                }

                OnPropertyChanged(nameof(SelectedSekce));
            }
        }

        public ICommand AddKnihaCommand { get; }
        public ICommand UpdateKnihaCommand { get; }
        public ICommand DeleteKnihaCommand { get; }

        public KnihaViewModel()
        {
            _repository = new LibraryRepository();
            LoadKnihy();
            LoadSekce();

            EditingKniha = new Kniha();

            AddKnihaCommand = new RelayCommand(AddKniha);
            UpdateKnihaCommand = new RelayCommand(UpdateKniha, CanModifyKniha);
            DeleteKnihaCommand = new RelayCommand(DeleteKniha, CanModifyKniha);

            FilteredKnihy = CollectionViewSource.GetDefaultView(Knihy);
            FilteredKnihy.Filter = FilterBooks;
        }

        private bool FilterBooks(object obj)
        {
            if (obj is Kniha kniha)
            {
                if (string.IsNullOrEmpty(SearchQuery))
                    return true;

                return kniha.ISBN?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       kniha.Nazev?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       kniha.Autor?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                       kniha.Zanr?.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return false;
        }

        private void LoadKnihy()
        {
            Knihy.Clear();
            foreach (var kniha in _repository.GetAllKnihy())
            {
                Knihy.Add(kniha);
            }
        }

        private void LoadSekce()
        {
            SekceList.Clear();
            foreach (var sekce in _repository.GetAllSekce())
            {
                SekceList.Add(sekce);
            }
        }

        private void AddKniha()
        {
            if (EditingKniha == null)
            {
                MessageBox.Show("EditingKniha is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SelectedSekce == null)
            {
                MessageBox.Show("Please select a Sekce first.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newKniha = new Kniha
            {
                ISBN = EditingKniha.ISBN,
                Nazev = EditingKniha.Nazev,
                Autor = EditingKniha.Autor,
                RokVydani = EditingKniha.RokVydani,
                Zanr = SelectedSekce.Kategorie,
                Nakladatelstvi = EditingKniha.Nakladatelstvi,
                SekceId = SelectedSekce.Id
            };

            _repository.AddKniha(newKniha);
            Knihy.Add(newKniha);

            EditingKniha = new Kniha();
        }

        private void UpdateKniha()
        {
            if (SelectedKniha != null && EditingKniha != null)
            {
                SelectedKniha.ISBN = EditingKniha.ISBN;
                SelectedKniha.Nazev = EditingKniha.Nazev;
                SelectedKniha.Autor = EditingKniha.Autor;
                SelectedKniha.RokVydani = EditingKniha.RokVydani;
                SelectedKniha.Zanr = EditingKniha.Zanr;
                SelectedKniha.Nakladatelstvi = EditingKniha.Nakladatelstvi;

                if (SelectedSekce != null)
                {
                    SelectedKniha.SekceId = SelectedSekce.Id;
                    SelectedKniha.Zanr = SelectedSekce.Kategorie;
                }

                _repository.UpdateKniha(SelectedKniha);

                LoadKnihy();
            }
        }

        private void DeleteKniha()
        {
            if (SelectedKniha != null)
            {
                _repository.DeleteKniha(SelectedKniha.ISBN);
                Knihy.Remove(SelectedKniha);
                EditingKniha = new Kniha();
            }
        }

        private bool CanModifyKniha() => SelectedKniha != null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
