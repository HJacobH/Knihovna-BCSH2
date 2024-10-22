using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnihovnaBCSH2
{
    public class SekceKnihovny
    {
        [BsonId] 
        public string Id { get; set; } 
        public string Room { get; set; } 
        public string Category { get; set; } 
        public string Description { get; set; } 
        public List<string> BookIds { get; set; }
    }
}
