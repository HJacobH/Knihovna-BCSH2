using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnihovnaBCSH2
{
    public class Ctenar
    {
        public string Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public List<string> VypujceneKnihy { get; set; } = new List<string>(); 
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
