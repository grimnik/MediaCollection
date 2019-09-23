using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MusicListViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Album> Albums { get; set; }
        
        public TimeSpan Duration { get; set; }
    }
}
