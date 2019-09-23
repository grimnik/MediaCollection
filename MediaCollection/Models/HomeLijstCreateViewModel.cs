using MediaCollection.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class HomeLijstCreateViewModel
    {
      
        [Required]
        public string Naam { get; set; }
        public int UserId { get; set; }
        public bool Public { get; set; }
        public string[] SelectedMovie { get; set; }
        public List<SelectListItem> MovieList { get; set; }
   
    }
}
