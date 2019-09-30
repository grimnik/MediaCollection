using MediaCollection.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Models
{
    public class SerieCreateViewModel
    {
        [Required(ErrorMessage = "Je moe wel een name ingeven eh!")]
        [DataType(DataType.Text, ErrorMessage ="Da is gin text e menneke!")]
        public string Naam { get; set; }
        
        public List<SeizoenCreate> Seizoen { get; set; }
       
       

      
    }

    public class SeizoenCreate
    {
        public List<AfleveringCreate> Afleveringen { get; set; }
        public int Nummer { get; set; }
        
    }
    public class AfleveringCreate
    {
        [Required(ErrorMessage = "Je moe wel een name ingeven eh!")]
        [DataType(DataType.Text, ErrorMessage = "Da is gin text e menneke!")]

        public string Naam { get; set; }
        [Required(ErrorMessage = "Je moe wel een beschrieving ingeven eh!")]
        [DataType(DataType.Text, ErrorMessage = "Da is gin text e menneke!")]
        public string Beschrijving { get; set; }
    }
}
