using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCH2Knihovna.Classes
{
    public class LibraryRepository : IDisposable
    {
        private readonly LiteDatabase _context;

        private const string DatabasePath = @"LibraryData.db";

        public LibraryRepository()
        {
            _context = new LiteDatabase(DatabasePath);
        }

        public IEnumerable<Kniha> GetAllKnihy() => _context.GetCollection<Kniha>("Knihy").FindAll();

        public void AddKniha(Kniha kniha) => _context.GetCollection<Kniha>("Knihy").Insert(kniha);

        public void UpdateKniha(Kniha kniha) => _context.GetCollection<Kniha>("Knihy").Update(kniha);

        public void DeleteKniha(string id) => _context.GetCollection<Kniha>("Knihy").Delete(id);

        public IEnumerable<Sekce> GetAllSekce()
        {
            var sekceList = _context.GetCollection<Sekce>("Sekce").FindAll().ToList();

            var knihyCollection = _context.GetCollection<Kniha>("Knihy");
            foreach (var sekce in sekceList)
            {
                sekce.Knihy = knihyCollection.Find(k => k.SekceId == sekce.Id).ToList();
            }

            return sekceList;
        }
        public void AddSekce(Sekce sekce) => _context.GetCollection<Sekce>("Sekce").Insert(sekce);

        public void UpdateSekce(Sekce sekce) => _context.GetCollection<Sekce>("Sekce").Update(sekce);

        public void DeleteSekce(int id) => _context.GetCollection<Sekce>("Sekce").Delete(id);

        public IEnumerable<Ctenar> GetAllCtenari() => _context.GetCollection<Ctenar>("Ctenari").FindAll();

        public void AddCtenar(Ctenar ctenar)
        {
            if (ctenar == null) return;

            var collection = _context.GetCollection<Ctenar>("Ctenari");

            collection.Insert(ctenar);
        }
        public void UpdateCtenar(Ctenar ctenar)
        {
            _context.GetCollection<Ctenar>("Ctenari").Update(ctenar);
        }

        public void DeleteCtenar(int id)
        {
            _context.GetCollection<Ctenar>("Ctenari").Delete(id);
        }

        public IEnumerable<Vypujceni> GetAllVypujceni()
        {
            var vypujceniList = _context.GetCollection<Vypujceni>("Vypujceni").FindAll().ToList();

            var knihyDict = _context.GetCollection<Kniha>("Knihy")
                                    .FindAll()
                                    .ToDictionary(k => k.Id, k => k.Nazev);

            var ctenariDict = _context.GetCollection<Ctenar>("Ctenari")
                                      .FindAll()
                                      .ToDictionary(c => c.Id, c => c.Jmeno);

            foreach (var vypujceni in vypujceniList)
            {
                if (knihyDict.TryGetValue(vypujceni.KnihaId, out string bookName))
                    vypujceni.BookName = bookName;
                else
                    vypujceni.BookName = "Unknown Book";

                if (ctenariDict.TryGetValue(vypujceni.CtenarId, out string ctenarName))
                    vypujceni.CtenarName = ctenarName;
                else
                    vypujceni.CtenarName = "Unknown Reader";
            }

            return vypujceniList;
        }



        public void AddVypujceni(Vypujceni vypujceni) => _context.GetCollection<Vypujceni>("Vypujceni").Insert(vypujceni);

        public void UpdateVypujceni(Vypujceni vypujceni)
        {
            var collection = _context.GetCollection<Vypujceni>("Vypujceni");

            if (!collection.Update(vypujceni))
            {
                throw new Exception("Update failed. Record not found.");
            }
        }

        public void DeleteVypujceni(int id) => _context.GetCollection<Vypujceni>("Vypujceni").Delete(id);

        public IEnumerable<Vypujceni> GetBorrowingsByCtenarId(int ctenarId)
        {
            return _context.GetCollection<Vypujceni>("Vypujceni")
                           .Find(v => v.CtenarId == ctenarId);
        }


        public void ClearCollection(string collectionName)
        {
            _context.DropCollection(collectionName);
        }

        public void ClearDatabase()
        {
            foreach (var collectionName in _context.GetCollectionNames())
            {
                _context.DropCollection(collectionName);
            }
        }

        public void DeleteDatabaseFile()
        {
            _context.Dispose(); 
            if (File.Exists(DatabasePath))
            {
                File.Delete(DatabasePath);
            }
        }

        public void ClearKnihaSekce(int sekceId)
        {
            var knihyCollection = _context.GetCollection<Kniha>("Knihy");

            var knihyToUpdate = knihyCollection.Find(k => k.SekceId == sekceId).ToList();

            foreach (var kniha in knihyToUpdate)
            {
                kniha.Zanr = null;
                kniha.SekceId = 0;
                knihyCollection.Update(kniha);
            }
        }
        public void Dispose() => _context.Dispose();
    }
}
