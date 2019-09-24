using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class SerieCreateViewModel
    {
        public string Naam { get; set; }
        public Seizoen Seizoen { get; set; }
        public Aflevering Aflevering { get; set; }
    }
}
