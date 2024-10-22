using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnihovnaBCSH2
{
    public class Kniha
    {
        [BsonId] 
        public ObjectId Id { get; set; } 
        public string ISBN { get; set; }
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public string Zanr { get; set; }
        public string Nakladatelstvi { get; set; }
        public string SekceId { get; set; }
    }

}
