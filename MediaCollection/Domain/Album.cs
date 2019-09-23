using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int AantalNummers { get; set; }
        public DateTime Duration { get; set; }
        public Artist Artist { get; set; }
        public TimeSpan ReleaseDate { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}
