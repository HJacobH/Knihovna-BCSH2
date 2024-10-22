using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnihovnaBCSH2
{
    public class Vypujceni
    {
        public int Id { get; set; }
        public string KnihaId { get; set; }
        public string CtenarId { get; set; }
        public DateTime DatumVypujceni { get; set; }
        public DateTime DatumDo { get; set; }
        public DateTime? DatumVraceni { get; set; }
    }
}
