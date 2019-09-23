using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MovieCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Beschrijving { get; set; }
        
        public IFormFile Foto { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}
