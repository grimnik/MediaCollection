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

        public List<SeizoenCreate> Seizoen { get; set; }
       
       

      
    }

    public class SeizoenCreate
    {
        public List<AfleveringCreate> Afleveringen { get; set; }
        public int Nummer { get; set; }
    }
    public class AfleveringCreate
    {
        
        public string Naam { get; set; }
    }
}
