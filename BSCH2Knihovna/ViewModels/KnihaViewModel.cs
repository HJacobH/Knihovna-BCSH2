using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna.ViewModels
{
    using BSCH2Knihovna.Classes;
    using BSCH2Knihovna.Commands;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;

    public class KnihaViewModel : INotifyPropertyChanged
    {
        private readonly LibraryRepository _repository;

        public ObservableCollection<Kniha> Knihy { get; set; } = new ObservableCollection<Kniha>();
        public ObservableCollection<Sekce> SekceList { get; set; } = new ObservableCollection<Sekce>(); 
        public Kniha SelectedKniha { get; set; } = new Kniha();
        public Sekce SelectedSekce { get; set; } 

        public ICommand AddKnihaCommand { get; }
        public ICommand UpdateKnihaCommand { get; }
        public ICommand DeleteKnihaCommand { get; }

        public KnihaViewModel()
        {
            _repository = new LibraryRepository();
            LoadKnihy();
            LoadSekce();

            AddKnihaCommand = new RelayCommand(AddKniha);
            UpdateKnihaCommand = new RelayCommand(UpdateKniha, CanModifyKniha);
            DeleteKnihaCommand = new RelayCommand(DeleteKniha, CanModifyKniha);
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
            if (SelectedSekce == null) return;

            var newKniha = new Kniha
            {
                ISBN = SelectedKniha.ISBN,
                Nazev = SelectedKniha.Nazev,
                Autor = SelectedKniha.Autor,
                RokVydani = SelectedKniha.RokVydani,
                Zanr = SelectedSekce.Kategorie,
                Nakladatelstvi = SelectedKniha.Nakladatelstvi,
                SekceId = SelectedSekce.Id 
            };

            _repository.AddKniha(newKniha);
            Knihy.Add(newKniha);
            SelectedKniha = new Kniha();
        }

        private void UpdateKniha()
        {
            if (SelectedKniha != null)
            {
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
                SelectedKniha = new Kniha();
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
