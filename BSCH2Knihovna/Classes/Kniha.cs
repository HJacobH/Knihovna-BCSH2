using LiteDB;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BSCH2Knihovna
{
    public class Kniha : INotifyPropertyChanged, IDataErrorInfo
    {
        [BsonId]
        public int Id { get; set; }

        private string _isbn;
        public string ISBN
        {
            get => _isbn;
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        private string _nazev;
        public string Nazev
        {
            get => _nazev;
            set
            {
                _nazev = value;
                OnPropertyChanged(nameof(Nazev));
            }
        }

        private string _autor;
        public string Autor
        {
            get => _autor;
            set
            {
                _autor = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

        private int _rokVydani;
        public int RokVydani
        {
            get => _rokVydani;
            set
            {
                _rokVydani = value;
                OnPropertyChanged(nameof(RokVydani));
            }
        }

        private string _nakladatelstvi;
        public string Nakladatelstvi
        {
            get => _nakladatelstvi;
            set
            {
                _nakladatelstvi = value;
                OnPropertyChanged(nameof(Nakladatelstvi));
            }
        }

        private string _zanr;
        public string Zanr
        {
            get => _zanr;
            set
            {
                _zanr = value;
                OnPropertyChanged(nameof(Zanr));
            }
        }

        public int SekceId { get; set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ISBN):
                        if (string.IsNullOrWhiteSpace(ISBN))
                            return "ISBN is required.";
                        if (!Regex.IsMatch(ISBN, @"^\d+$"))
                            return "ISBN must contain only numbers.";
                        return null;

                    case nameof(Nazev):
                        return string.IsNullOrWhiteSpace(Nazev) ? "Book title is required." : null;

                    case nameof(Autor):
                        return string.IsNullOrWhiteSpace(Autor) ? "Author is required." : null;

                    case nameof(RokVydani):
                        return RokVydani <= 0 || RokVydani > DateTime.Now.Year
                            ? "Invalid publication year." : null;

                    case nameof(Nakladatelstvi):
                        return string.IsNullOrWhiteSpace(Nakladatelstvi) ? "Publisher is required." : null;

                    default:
                        return null;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
