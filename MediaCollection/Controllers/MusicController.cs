using MediaCollection.Data;
using MediaCollection.Domain;
using MediaCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public MusicController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult Music()
        {
            List<MusicListViewModel> artist = new List<MusicListViewModel>();
            IEnumerable<Artist> artistsFromDb = _appContext.Artists.ToArray();
          

            foreach (var item in artistsFromDb)
            {
                artist.Add(new MusicListViewModel()
                {
                    Id = item.Id,
                    Naam = item.Naam,

                });

            }
            return View(artist);
        }
        public IActionResult SongCreate()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SongCreate(MusicSongCreateViewModel model)
        {
            IEnumerable<Artist> artists = _appContext.Artists.Where(a => a.Naam == model.Artist.Naam);
            IEnumerable<Songs> songs = _appContext.Songs.Where(s => s.Title == model.Title);
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            if (artists.Count() == 0)
            {

                Artist artist = new Artist()
                {
                    Naam = model.Artist.Naam
                };
                _appContext.Artists.Add(artist);
                _appContext.SaveChanges();
                if (songs.Count()== 0)
                {
                    Songs song = new Songs()
                    {
                        Title = model.Title,
                        Duration = model.Duration,
                        Artist = artist
                    };
                    _appContext.Songs.Add(song);
                    _appContext.SaveChanges();
                    ArtistAlbumSong Aas = new ArtistAlbumSong()
                    {
                        ArtistId = artist.Id,
                        SongId = song.Id
                    };

                    _appContext.ArtistAlbumSongs.Add(Aas);
                    _appContext.SaveChanges();
                }
            }
            else
            {
                if (songs.Count() == 0)
                {
                    Songs song = new Songs()
                    {
                        Title = model.Title,
                        Duration = model.Duration,
                        Artist = artists.FirstOrDefault(x => x.Naam == model.Artist.Naam)
                    };
                    _appContext.Songs.Add(song);
                    _appContext.SaveChanges();
                    ArtistAlbumSong Aas = new ArtistAlbumSong()
                    {
                        ArtistId = song.Artist.Id,
                        SongId = song.Id
                    };
                    _appContext.ArtistAlbumSongs.Add(Aas);
                    _appContext.SaveChanges();
                }
                
            }
            return RedirectToAction("Music");
        }
        public IActionResult ArtistDetail(int id)
        {
            Artist artist = _appContext.Artists.FirstOrDefault(x => x.Id == id);
            IEnumerable<Album> albums = _appContext.Albums.Where(a => a.Artist == artist);
            IEnumerable<Songs> songs = _appContext.Songs.Where(s => s.Artist == artist);

            List<string> albumTitles = new List<string>();
            List<string> songTitles = new List<string>();
            List<MusicDetailViewModel> vm = new List<MusicDetailViewModel>();


            MusicDetailViewModel musicDetail = new MusicDetailViewModel()
            {
                ArtistName = artist.Naam,
                Albums = albums.ToArray(),
                Songs = songs.ToArray()
            };
            vm.Add(musicDetail);


            return View(musicDetail);
        }
    }
}
