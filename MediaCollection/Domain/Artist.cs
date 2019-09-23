using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
