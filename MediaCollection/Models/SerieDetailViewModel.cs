using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class SerieDetailViewModel
    {
        public string Naam { get; set; }
        public IEnumerable<Seizoen> Seizoenen { get; set; }
        public IEnumerable<Aflevering> Afleveringen { get; set; }
    }
}
