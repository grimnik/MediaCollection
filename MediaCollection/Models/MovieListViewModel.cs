using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MovieListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Beschrijving { get; set; }
        public string Review { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
