using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MusicDetailViewModel
    {
        public string ArtistName { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
