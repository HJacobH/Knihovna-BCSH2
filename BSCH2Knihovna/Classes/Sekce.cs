using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna
{
    public class Sekce
    {
        [BsonId] 
        public int Id { get; set; } 

        public string Mistnost { get; set; }
        public string Kategorie { get; set; }
        public string Popis { get; set; }

        public List<Kniha> Knihy { get; set; } = new List<Kniha>();
    }

}
