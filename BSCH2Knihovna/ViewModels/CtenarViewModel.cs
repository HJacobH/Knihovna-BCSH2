using BSCH2Knihovna.Classes;
using BSCH2Knihovna.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BSCH2Knihovna.ViewModels
{
    public class CtenarViewModel : INotifyPropertyChanged
    {
        private readonly LibraryRepository _repository;

        public ObservableCollection<Ctenar> Ctenari { get; set; } = new ObservableCollection<Ctenar>();
        public ObservableCollection<Kniha> Knihy { get; set; } = new ObservableCollection<Kniha>();

        private Kniha _selectedKniha;

        private Ctenar _editingCtenar;
        public Ctenar EditingCtenar
        {
            get => _editingCtenar;
            set
            {
                _editingCtenar = value;
                OnPropertyChanged(nameof(EditingCtenar));
            }
        }
        private ObservableCollection<Vypujceni> _borrowedBooks = new ObservableCollection<Vypujceni>();

        private Ctenar _selectedCtenar;
        public Ctenar SelectedCtenar
        {
            get => _selectedCtenar;
            set
            {
                _selectedCtenar = value;

                if (_selectedCtenar != null)
                {
                    EditingCtenar = new Ctenar
                    {
                        Id = _selectedCtenar.Id,
                        Jmeno = _selectedCtenar.Jmeno,
                        Prijmeni = _selectedCtenar.Prijmeni,
                        Telefon = _selectedCtenar.Telefon,
                        Email = _selectedCtenar.Email
                    };

                    var borrowings = _repository.GetBorrowingsByCtenarId(_selectedCtenar.Id);

                    _borrowedBooks.Clear();
                    foreach (var borrowing in borrowings)
                    {
                        var book = _repository.GetAllKnihy().FirstOrDefault(k => k.Id == borrowing.KnihaId);
                        borrowing.BookName = book != null ? book.Nazev : "Unknown Book";

                        _borrowedBooks.Add(borrowing);
                    }
                }
                else
                {
                    EditingCtenar = new Ctenar();
                    _borrowedBooks.Clear();
                }

                OnPropertyChanged(nameof(SelectedCtenar));
                OnPropertyChanged(nameof(EditingCtenar));
                OnPropertyChanged(nameof(BorrowedBooks));
            }
        }

        public ObservableCollection<Vypujceni> BorrowedBooks
        {
            get => _borrowedBooks;
            set
            {
                _borrowedBooks = value;
                OnPropertyChanged(nameof(BorrowedBooks));
            }
        }

        private void LoadCtenari()
        {
            Ctenari = new ObservableCollection<Ctenar>(_repository.GetAllCtenari());
            OnPropertyChanged(nameof(Ctenari));
        }

        public ICommand AddCtenarCommand { get; }
        public ICommand UpdateCtenarCommand { get; }
        public ICommand DeleteCtenarCommand { get; }

        public CtenarViewModel()
        {
            _repository = new LibraryRepository();
            LoadCtenari();

            EditingCtenar = new Ctenar();

            AddCtenarCommand = new RelayCommand(AddCtenar);
            UpdateCtenarCommand = new RelayCommand(UpdateCtenar, CanModifyCtenar);
            DeleteCtenarCommand = new RelayCommand(DeleteCtenar, CanModifyCtenar);
        }

        private void AddCtenar()
        {
            if (EditingCtenar == null) return;

            if (string.IsNullOrWhiteSpace(EditingCtenar.Jmeno) ||
                string.IsNullOrWhiteSpace(EditingCtenar.Prijmeni))
            {
                MessageBox.Show("Please fill out all required fields.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newCtenar = new Ctenar
            {
                Jmeno = EditingCtenar.Jmeno,
                Prijmeni = EditingCtenar.Prijmeni,
                Telefon = EditingCtenar.Telefon,
                Email = EditingCtenar.Email
            };

            _repository.AddCtenar(newCtenar);
            Ctenari.Add(newCtenar);

            EditingCtenar = new Ctenar();
            OnPropertyChanged(nameof(EditingCtenar));

            MessageBox.Show("New reader added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateCtenar()
        {
            if (SelectedCtenar == null || EditingCtenar == null) return;

            var existingBorrowings = SelectedCtenar.VypujceneKnihy;

            SelectedCtenar.Jmeno = EditingCtenar.Jmeno;
            SelectedCtenar.Prijmeni = EditingCtenar.Prijmeni;
            SelectedCtenar.Telefon = EditingCtenar.Telefon;
            SelectedCtenar.Email = EditingCtenar.Email;

            SelectedCtenar.VypujceneKnihy = existingBorrowings;

            _repository.UpdateCtenar(SelectedCtenar);

            LoadCtenari();

            MessageBox.Show("Reader updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void DeleteCtenar()
        {
            if (SelectedCtenar == null) return;

            _repository.DeleteCtenar(SelectedCtenar.Id);
            Ctenari.Remove(SelectedCtenar);
            SelectedCtenar = null;
            OnPropertyChanged(nameof(BorrowedBooks));
            MessageBox.Show("Reader deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanModifyCtenar() => SelectedCtenar != null;


        public Kniha SelectedKniha
        {
            get => _selectedKniha;
            set
            {
                _selectedKniha = value;
                OnPropertyChanged(nameof(SelectedKniha));
            }
        }

        public ICommand BorrowBookCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
