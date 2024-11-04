using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.Collections.Generic;


namespace BSCH2Knihovna.Classes
{

    public class LibraryDbContext
    {
        private readonly LiteDatabase _database;

        public LibraryDbContext()
        {
            _database = new LiteDatabase(@"LibraryData.db");
        }

        public ILiteCollection<Kniha> Knihy => _database.GetCollection<Kniha>("knihy");
        public ILiteCollection<Vypujceni> Vypujceni => _database.GetCollection<Vypujceni>("vypujceni");
        public ILiteCollection<Ctenar> Ctenari => _database.GetCollection<Ctenar>("ctenari");
        public ILiteCollection<Sekce> Sekce => _database.GetCollection<Sekce>("sekce");

        public void Dispose()
        {
            _database?.Dispose();
        }
    }

}
