using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaCollection.Models;
using MediaCollection.Domain;
using MediaCollection.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MediaCollection.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _appContext { get; set; }
        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MovieMain()
        {
            return View();
        }
        public IActionResult Lijst()
        {
            List<AfspeelLijstListViewModel> afspeelLijsts = new List<AfspeelLijstListViewModel>();
            IEnumerable<AfspeelLijst> afspeelLijstsFromDb = _appContext.AfspeelLijsten.ToArray();
            ICollection<AfspeelLijstMovie> afspeelLijstMovies = _appContext.AfspeelLijstMovies.ToArray();

            foreach (var item in afspeelLijstsFromDb)
            {
                afspeelLijsts.Add(new AfspeelLijstListViewModel()
                {
                    Id = item.Id,
                    Naam = item.Naam,
                    UserId = item.UserId,
                   AfspeelLijstMovies = afspeelLijstMovies,
                    identityUsers = item.identityUsers,
                    Public = item.Public
                });
            }
            return View(afspeelLijsts);
        }
        public IActionResult LijstCreate()
        {
            Movie[] moviesFromDb = _appContext.Movies.ToArray();
            List<SelectListItem> movies = new List<SelectListItem>();
            foreach (var item in moviesFromDb)
            {
                movies.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                  Text = item.Title
                });
            }
            HomeLijstCreateViewModel model = new HomeLijstCreateViewModel()
            {
                MovieList = movies
            };
            
            
            return View(model);
        }
        [HttpPost]
        public IActionResult LijstCreate(HomeLijstCreateViewModel model)
        {
            Movie[] moviesFromDb = _appContext.Movies.ToArray();
            List<SelectListItem> movies = new List<SelectListItem>();

         

            foreach (var item in moviesFromDb)
            {
                movies.Add(new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Title
                });
            }
            HomeLijstCreateViewModel vm = new HomeLijstCreateViewModel()
            {
                MovieList = movies
            };
            model.MovieList = new List<SelectListItem>();
            foreach (var item in vm.MovieList)
            {
                model.MovieList.Add(new SelectListItem()
                {
                    Value = item.Value,
                    Text = item.Text
                });
            }

            if (!TryValidateModel(model))
            {
                return View(model);
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AfspeelLijst afspeelLijst = new AfspeelLijst()
            {

                Naam = model.Naam,
               UserId =userId
            };
               
            _appContext.AfspeelLijsten.Add(afspeelLijst);
            _appContext.SaveChanges();
            foreach (var item in model.SelectedMovie)
            {
              var movie =  _appContext.Movies.Where(x => x.Id == int.Parse(item)).ToList();
              
            foreach (var film in movie)
            {
                    AfspeelLijstMovie afspeelLijstMovie = new AfspeelLijstMovie()
                    {
                        MovieId = film.Id,
                        AfspeelLijstId = afspeelLijst.Id
                    };
                    _appContext.AfspeelLijstMovies.Add(afspeelLijstMovie);
                    _appContext.SaveChanges();
            }
            }
           
            return RedirectToAction("LijstCreate", "Home");
        }
        public IActionResult AfspeelDetail(int id)
        {
            AfspeelLijst afspeelLijst = _appContext.AfspeelLijsten.FirstOrDefault(x => x.Id == id);
            var afspeellijstmovies = _appContext.AfspeelLijstMovies.ToArray();
            List<string> movieTitles = new List<string>();
            List<AfspeelLijstDetailViewModel> vm = new List<AfspeelLijstDetailViewModel>();
            foreach (var item in afspeellijstmovies)
            {
                if (item.AfspeelLijstId == id )
                {
                    List<Movie> moviesFrmDb = _appContext.Movies.Where(x => x.Id == item.MovieId).ToList();
                    foreach (var movie in moviesFrmDb)
                    {
                        movieTitles.Add(movie.Title);
                    }
                }
               
            }
                    var user = _appContext.Users.FirstOrDefault(u => u.Id == afspeelLijst.UserId);
                    AfspeelLijstDetailViewModel afspeelLijstDetailViewModel = new AfspeelLijstDetailViewModel()
                    {
                        UserCreator = user.UserName,
                        MovieTitles = movieTitles,
                        Naam = afspeelLijst.Naam
                        
                        

                    };
            vm.Add(afspeelLijstDetailViewModel);
            return View(vm);
        }
        
    }
}
