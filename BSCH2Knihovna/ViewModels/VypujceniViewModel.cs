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
    public class VypujceniViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly LibraryRepository _repository;

        private Vypujceni _selectedVypujceni;
        private Vypujceni _editingVypujceni;

        public ObservableCollection<Vypujceni> VypujceniList { get; set; }
        public ObservableCollection<Kniha> KnihyList { get; set; }
        public ObservableCollection<Ctenar> CtenariList { get; set; }

        public ICommand AddVypujceniCommand { get; }
        public ICommand UpdateVypujceniCommand { get; }
        public ICommand DeleteVypujceniCommand { get; }

        public Vypujceni SelectedVypujceni
        {
            get => _selectedVypujceni;
            set
            {
                _selectedVypujceni = value;

                if (_selectedVypujceni != null)
                {
                    EditingVypujceni = new Vypujceni
                    {
                        Id = _selectedVypujceni.Id,
                        KnihaId = _selectedVypujceni.KnihaId,
                        CtenarId = _selectedVypujceni.CtenarId,
                        DatumVypujceni = _selectedVypujceni.DatumVypujceni,
                        DatumVratenka = _selectedVypujceni.DatumVratenka,
                        DatumVratu = _selectedVypujceni.DatumVratu
                    };
                }
                else
                {
                    EditingVypujceni = new Vypujceni();
                }

                OnPropertyChanged(nameof(SelectedVypujceni));
            }
        }
        public Vypujceni EditingVypujceni
        {
            get => _editingVypujceni;
            set
            {
                _editingVypujceni = value;
                OnPropertyChanged(nameof(EditingVypujceni));
            }
        }

        public VypujceniViewModel()
        {
            _repository = new LibraryRepository();

            VypujceniList = new ObservableCollection<Vypujceni>(_repository.GetAllVypujceni());
            KnihyList = new ObservableCollection<Kniha>(_repository.GetAllKnihy());
            CtenariList = new ObservableCollection<Ctenar>(_repository.GetAllCtenari());

            SelectedVypujceni = new Vypujceni();
            EditingVypujceni = new Vypujceni();

            AddVypujceniCommand = new RelayCommand(AddVypujceni);
            UpdateVypujceniCommand = new RelayCommand(UpdateVypujceni, CanModifyVypujceni);
            DeleteVypujceniCommand = new RelayCommand(DeleteVypujceni, CanModifyVypujceni);
        }

        private void AddVypujceni()
        {
            if (EditingVypujceni.KnihaId <= 0 || EditingVypujceni.CtenarId <= 0)
            {
                MessageBox.Show("Please select a valid book and reader.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isBookBorrowed = VypujceniList.Any(v => v.KnihaId == EditingVypujceni.KnihaId && v.DatumVratu == null);
            if (isBookBorrowed)
            {
                MessageBox.Show("This book is already borrowed and not yet returned.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newVypujceni = new Vypujceni
            {
                KnihaId = EditingVypujceni.KnihaId,
                CtenarId = EditingVypujceni.CtenarId,
                DatumVypujceni = DateTime.Now,
                DatumVratenka = DateTime.Now.AddDays(14) 
            };

            _repository.AddVypujceni(newVypujceni);
            VypujceniList.Add(newVypujceni);

            EditingVypujceni = new Vypujceni();
            OnPropertyChanged(nameof(EditingVypujceni));
        }


        private void UpdateVypujceni()
        {
            if (SelectedVypujceni == null)
            {
                MessageBox.Show("No borrowing selected for update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isBookBorrowedByAnother = VypujceniList.Any(v =>
                v.KnihaId == EditingVypujceni.KnihaId &&
                v.Id != SelectedVypujceni.Id &&
                v.DatumVratu == null);

            if (isBookBorrowedByAnother)
            {
                MessageBox.Show("This book is already borrowed by another reader and not yet returned.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SelectedVypujceni.KnihaId = EditingVypujceni.KnihaId;
            SelectedVypujceni.CtenarId = EditingVypujceni.CtenarId;
            SelectedVypujceni.DatumVratu = EditingVypujceni.DatumVratu;

            _repository.UpdateVypujceni(SelectedVypujceni);

            RefreshVypujceniList();
            MessageBox.Show("Borrowing updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void DeleteVypujceni()
        {
            if (SelectedVypujceni == null) return;

            _repository.DeleteVypujceni(SelectedVypujceni.Id);
            VypujceniList.Remove(SelectedVypujceni);

            EditingVypujceni = new Vypujceni();
            OnPropertyChanged(nameof(EditingVypujceni));
        }

        private bool CanModifyVypujceni() => SelectedVypujceni != null;

        private void RefreshVypujceniList()
        {
            VypujceniList.Clear();
            foreach (var item in _repository.GetAllVypujceni())
            {
                VypujceniList.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Dispose() => _repository.Dispose();
    }

}
