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

        public SeizoenCreate[] Seizoenen {get;set;}

        //public Seizoen Seizoen { get; set; }
        //public Aflevering Aflevering { get; set; }
        public int[] Hoeveelste { get; set; }
    }

    public class SeizoenCreate
    {
        public int Nummer { get; set; }
        public string[] Afleveringen { get; set; }
    }
}
