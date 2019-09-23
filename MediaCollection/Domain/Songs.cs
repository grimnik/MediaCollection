using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class Songs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Album> Albums { get; set; }
        public Artist Artist { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
