using MediaCollection.Data;
using MediaCollection.Domain;
using MediaCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Controllers
{
    public class MovieController :Controller
    {
        private readonly ApplicationDbContext _appContext;
        public MovieController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult MovieMain()
        {
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            IEnumerable<Movie> moviesFromDb = _appContext.Movies.ToArray();

            foreach (var item in moviesFromDb)
            {
                movies.Add(new MovieListViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Beschrijving = item.Beschrijving,
                    ReleaseDate = item.ReleaseDate,
                    Foto = item.Foto
                });
            }
            return View(movies);
        }
        public IActionResult MovieCreate()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MovieCreate(MovieCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            var movie = new Movie()
            {
                Title = model.Title,
                Beschrijving = model.Beschrijving,
                
                ReleaseDate = model.ReleaseDate,
                
            };
            using (var memoryStream = new MemoryStream())
            {
                await model.Foto.CopyToAsync(memoryStream);
                movie.Foto = memoryStream.ToArray();

            }
            _appContext.Movies.Add(movie);
            _appContext.SaveChanges();
            return RedirectToAction("MovieMain","Movie");
        }
        public IActionResult MovieEdit(int id)
        {
            Movie movieFromDb = _appContext.Movies.FirstOrDefault(x => x.Id == id);
            MovieEditViewModel model = new MovieEditViewModel()
            {
                Id = movieFromDb.Id,
                Title = movieFromDb.Title,
                Beschrijving = movieFromDb.Beschrijving,
                ByteFoto = movieFromDb.Foto,
                ReleaseDate = movieFromDb.ReleaseDate
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MovieEdit(MovieEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            Movie movie = new Movie()
            {
                Id = model.Id,
                Title = model.Title,
                Beschrijving = model.Beschrijving,

                ReleaseDate = model.ReleaseDate,

            };
            using (var memoryStream = new MemoryStream())
            {
                await model.Foto.CopyToAsync(memoryStream);
                movie.Foto = memoryStream.ToArray();

            }
            _appContext.Movies.Update(movie);
            _appContext.SaveChanges();
            return RedirectToAction("MovieMain", "Movie");
        }
    }
}
