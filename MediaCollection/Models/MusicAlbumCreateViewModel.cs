using MediaCollection.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class MusicAlbumCreateViewModel
    {
        [Required(ErrorMessage = "Je moe wel een name ingeven eh!")]
        [DataType(DataType.Text, ErrorMessage = "Da is gin text e menneke!")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Je moe wel een artiest name ingeven eh!")]
        [DataType(DataType.Text, ErrorMessage = "Da is gin text e menneke!")]
        public string Artist { get; set; }
        public IFormFile Cover { get; set; }
    }
}
