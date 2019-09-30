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
            List<SerieListViewModel> series = new List<SerieListViewModel>();
            IEnumerable<Serie> seriesFromDb = _appContext.Series.ToArray();
            IEnumerable<Aflevering> afleveringenFromDb = _appContext.Afleveringen.ToArray();
            IEnumerable<Seizoen> seizoenenFromDb = _appContext.Seizoenen.ToArray();
          
            foreach (var item in seriesFromDb)
            {
               

                series.Add(new SerieListViewModel()
                {
                    Id = item.Id,
                    Naam = item.Naam,
                    Seizoenen = seizoenenFromDb,
                    Afleveringen = afleveringenFromDb

                    
                });
            }
            return View(series);
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
        public IActionResult SerieDetail(int id)
        {
            Serie serieFromDb = _appContext.Series.FirstOrDefault(s => s.Id == id);
            List<Seizoen> seizoenenFromDb = _appContext.Seizoenen.Where(s => s.SerieId == id).ToList();
            List<Aflevering> afleveringen = new List<Aflevering>();
            foreach (var item in seizoenenFromDb)
            {
                IEnumerable<Aflevering> afleveringenFromDb = _appContext.Afleveringen.Where(a => a.SeizoenId == item.Id);
                foreach (var item2 in afleveringenFromDb)
                {

                afleveringen.Add(item2);
                }
            };


            SerieDetailViewModel model = new SerieDetailViewModel()
            {
                Naam = serieFromDb.Naam,
                Seizoenen = seizoenenFromDb,
                Afleveringen = afleveringen
            };
            return View(model);
        }
        
    }
}
