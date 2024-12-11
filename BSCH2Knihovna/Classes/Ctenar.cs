using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BSCH2Knihovna.Classes
{
    public class Ctenar : INotifyPropertyChanged, IDataErrorInfo
    {
        [BsonId]
        public int Id { get; set; }

        private string _jmeno;
        public string Jmeno
        {
            get => _jmeno;
            set
            {
                _jmeno = value;
                OnPropertyChanged(nameof(Jmeno));
            }
        }

        private string _prijmeni;
        public string Prijmeni
        {
            get => _prijmeni;
            set
            {
                _prijmeni = value;
                OnPropertyChanged(nameof(Prijmeni));
            }
        }

        public List<Vypujceni> VypujceneKnihy { get; set; } = new List<Vypujceni>();

        private string _telefon;
        public string Telefon
        {
            get => _telefon;
            set
            {
                _telefon = value;
                OnPropertyChanged(nameof(Telefon));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Jmeno):
                        return string.IsNullOrWhiteSpace(Jmeno) ? "First Name is required." : null;

                    case nameof(Prijmeni):
                        return string.IsNullOrWhiteSpace(Prijmeni) ? "Last Name is required." : null;

                    case nameof(Telefon):
                        return !string.IsNullOrWhiteSpace(Telefon) && !Regex.IsMatch(Telefon, @"^\+?\d{9,15}$")
                               ? "Phone number must be between 9-15 digits and can include '+'." : null;

                    case nameof(Email):
                        return !string.IsNullOrWhiteSpace(Email) && !Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                               ? "Invalid email address format." : null;

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
