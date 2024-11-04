using BSCH2Knihovna.Classes;
using BSCH2Knihovna.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BSCH2Knihovna.ViewModels
{
    public class SekceViewModel : INotifyPropertyChanged
    {
        private Sekce _selectedSekce;
        private readonly LibraryRepository _repository;

        public ObservableCollection<Sekce> SekceList { get; set; } = new ObservableCollection<Sekce>();
        public Sekce SelectedSekce { get; set; } = new Sekce(); 

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

        public SekceViewModel()
        {
            _repository = new LibraryRepository();
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
            var newSekce = new Sekce
            {
                Mistnost = SelectedSekce.Mistnost,
                Kategorie = SelectedSekce.Kategorie,
                Popis = SelectedSekce.Popis
            };

            _repository.AddSekce(newSekce);
            SekceList.Add(newSekce);
            SelectedSekce = new Sekce();
        }

        private void UpdateSekce()
        {
            if (SelectedSekce != null)
            {
                _repository.UpdateSekce(SelectedSekce);
                LoadSekce(); 
            }
        }

        private void DeleteSekce()
        {
            if (SelectedSekce != null && SelectedSekce.Id != 0)
            {
                _repository.DeleteSekce(SelectedSekce.Id);
                SekceList.Remove(SelectedSekce);
                SelectedSekce = new Sekce(); 
            }
        }

        private bool CanModifySekce() => SelectedSekce != null && SelectedSekce.Id != 0;

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
