using MediaCollection.Data;
using MediaCollection.Domain;
using MediaCollection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Controllers
{
    public class SerieController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public SerieController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult Serie()
        {
            return View();
        }
        public IActionResult SerieCreate()
        {
            return View();
        }
       [HttpPost]
        public IActionResult MaakSerie(SerieCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            
            List<Seizoen> Seizoenen = new List<Seizoen>();
            foreach (var item in model.Seizoen)
            {
            List<Aflevering> Afleveringen = new List<Aflevering>();
                    int teller = 0;
                foreach (var item2 in item.Afleveringen)
                {
                    teller++;
                    if (item2 == null)
                    {
                        return RedirectToAction("SerieCreate", "Serie", model);
                        
                    }
                    Aflevering aflevering = new Aflevering()
                    {
                        Naam = item2.Naam,
                        Beschrijving = item2.Beschrijving,
                        Hoeveelste = teller
                    };
                    Afleveringen.Add(aflevering);
                }
                Seizoen seizoen = new Seizoen()
                {
                    Hoeveelste = item.Nummer,
                    Afleveringen = Afleveringen
                };
                Seizoenen.Add(seizoen);
            }
            var serie = new Serie()
            {
                Naam = model.Naam,
                Seizoenen = Seizoenen
            };
            _appContext.Series.Add(serie);
            _appContext.SaveChanges();

           return RedirectToAction("Serie","Serie");
        }
        
    }
}
