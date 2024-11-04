using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna.Classes
{
    public class Vypujceni
    {
        public int Id { get; set; }
        public int KnihaId { get; set; }
        public int CtenarId { get; set; }
        public DateTime DatumVypujceni { get; set; }
        public DateTime DatumVratenka { get; set; }
        public DateTime? DatumVratu { get; set; }
    }

}
