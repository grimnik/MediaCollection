using MediaCollection.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class AfspeelLijstListViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string UserId { get; set; }
        public bool Public { get; set; }
        public ICollection<AfspeelLijstMovie> AfspeelLijstMovies { get; set; }
        public IdentityUser[] identityUsers { get; set; }
    }
}
