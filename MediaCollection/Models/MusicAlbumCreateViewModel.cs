using MediaCollection.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MusicAlbumCreateViewModel
    {
        public string Title { get; set; }
        public ICollection<Songs> Songs { get; set; }
        public Artist Artist { get; set; }
        public IFormFile Cover { get; set; }
    }
}
