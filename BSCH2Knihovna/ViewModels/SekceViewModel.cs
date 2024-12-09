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
    public class SekceViewModel : INotifyPropertyChanged
    {
        private Sekce _selectedSekce;
        private Sekce _editingSekce;
        private readonly LibraryRepository _repository;

        public ObservableCollection<Sekce> SekceList { get; set; } = new ObservableCollection<Sekce>();

        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>
    {
        "Fiction",
        "Non-Fiction",
        "Science",
        "History",
        "Children's Books"
    };

        public ICommand AddSekceCommand { get; }
        public ICommand UpdateSekceCommand { get; }
        public ICommand DeleteSekceCommand { get; }

        public Sekce SelectedSekce
        {
            get => _selectedSekce;
            set
            {
                _selectedSekce = value;
                if (_selectedSekce != null)
                {
                    EditingSekce = new Sekce
                    {
                        Id = _selectedSekce.Id,
                        Mistnost = _selectedSekce.Mistnost,
                        Kategorie = _selectedSekce.Kategorie,
                        Popis = _selectedSekce.Popis
                    };
                }
                else
                {
                    EditingSekce = new Sekce();
                }

                OnPropertyChanged(nameof(SelectedSekce));
            }
        }

        public Sekce EditingSekce
        {
            get => _editingSekce;
            set
            {
                _editingSekce = value;
                OnPropertyChanged(nameof(EditingSekce));
            }
        }

        public SekceViewModel()
        {
            _repository = new LibraryRepository();
            SelectedSekce = new Sekce();
            LoadSekce();

            AddSekceCommand = new RelayCommand(AddSekce);
            UpdateSekceCommand = new RelayCommand(UpdateSekce, CanModifySekce);
            DeleteSekceCommand = new RelayCommand(DeleteSekce, CanModifySekce);
        }

        private void LoadSekce()
        {
            SekceList.Clear();
            var sekceData = _repository.GetAllSekce();
            foreach (var sekce in sekceData)
            {
                SekceList.Add(sekce);
            }
        }

        private void AddSekce()
        {
            if (EditingSekce == null)
            {
                EditingSekce = new Sekce();
            }

            if (string.IsNullOrWhiteSpace(EditingSekce.Mistnost) ||
                string.IsNullOrWhiteSpace(EditingSekce.Kategorie))
            {
                MessageBox.Show("Všechna pole musí být vyplněna", "Chybějící Informace!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newSekce = new Sekce
            {
                Mistnost = EditingSekce.Mistnost,
                Kategorie = EditingSekce.Kategorie,
                Popis = EditingSekce.Popis
            };

            _repository.AddSekce(newSekce);
            SekceList.Add(newSekce);

            EditingSekce = new Sekce();
            OnPropertyChanged(nameof(EditingSekce));
        }

        private void UpdateSekce()
        {
            if (SelectedSekce != null && EditingSekce != null)
            {
                SelectedSekce.Mistnost = EditingSekce.Mistnost;
                SelectedSekce.Kategorie = EditingSekce.Kategorie;
                SelectedSekce.Popis = EditingSekce.Popis;

                _repository.UpdateSekce(SelectedSekce);
                LoadSekce();
            }
        }

        private void DeleteSekce()
        {
            if (SelectedSekce != null && SelectedSekce.Id != 0)
            {
                _repository.ClearKnihaSekce(SelectedSekce.Id);

                _repository.DeleteSekce(SelectedSekce.Id);
                SekceList.Remove(SelectedSekce);
                SelectedSekce = new Sekce();

                OnPropertyChanged(nameof(SekceList));
            }
        }

        private bool CanModifySekce() => SelectedSekce != null && SelectedSekce.Id != 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void Dispose()
        {
            _repository.Dispose();
        }
    }

}
