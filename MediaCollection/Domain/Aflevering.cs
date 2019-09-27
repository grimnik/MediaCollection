using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Aflevering
    {
        public int Id { get; set; }
        public int Hoeveelste { get; set; }
        public string Beschrijving { get; set; }
        public string Naam { get; set; }
      
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
