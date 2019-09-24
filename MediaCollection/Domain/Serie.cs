using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Serie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Seizoen[] Seizoenen { get; set; }

    }
}
