using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna
{
    public class Kniha
    {
        [BsonId]
        public int Id { get; set; } 

        public string ISBN { get; set; }
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public string Nakladatelstvi { get; set; }
        public string Zanr { get; set; }
        public int SekceId { get; set; }
    }

}
