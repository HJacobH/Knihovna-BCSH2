using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace KnihovnaBCSH2
{

    public class Database
    {
        private LiteDatabase _db;

        public Database(string dbPath = "Library.db")
        {
            _db = new LiteDatabase(dbPath);
        }

        public ILiteCollection<Kniha> Knihy => _db.GetCollection<Kniha>("knihy");
        public ILiteCollection<Vypujceni> Vypujceni => _db.GetCollection<Vypujceni>("vypujceni");
        public ILiteCollection<Ctenar> Ctenari => _db.GetCollection<Ctenar>("ctenari");
        public ILiteCollection<SekceKnihovny> Sekce => _db.GetCollection<SekceKnihovny>("sekce");
    }

}
