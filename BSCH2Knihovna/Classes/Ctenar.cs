using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna.Classes
{
    public class Ctenar
    {
        [BsonId]
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public List<Vypujceni> VypujceneKnihy { get; set; } = new List<Vypujceni>();
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
