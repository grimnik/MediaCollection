using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MusicSongCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public Artist Artist { get; set; }
    }
}
