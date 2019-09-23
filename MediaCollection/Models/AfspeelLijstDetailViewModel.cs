using MediaCollection.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class AfspeelLijstDetailViewModel
    {
        public string Naam { get; set; }
        public string UserId { get; set; }
        public bool Public { get; set; }
        public IEnumerable<string> MovieTitles { get; set; }
        public string UserCreator { get; set; }
        public ICollection<AfspeelLijstMovie> AfspeelLijstMovies { get; set; }
        public IdentityUser[] identityUsers { get; set; }
    }
}
