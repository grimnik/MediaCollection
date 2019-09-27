using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Seizoen
    {
        public int Id { get; set; }
        public int Hoeveelste { get; set; }
        
        public List<Aflevering> Afleveringen { get; set; }
    }
}
