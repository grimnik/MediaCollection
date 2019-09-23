using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Domain
{
    public class ArtistAlbumSong
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }

    }
}
