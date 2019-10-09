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
            IEnumerable<Album> albums = _appContext.Albums.Where(a => a.Naam == model.Album.Naam);
            if (!TryValidateModel(model))
            {
                return View(model);
            }
            if (artists.Count() == 0)
            {
                if (model.Album.Naam == null)
                {

                    Artist artist = CreateArtist(model.Artist.Naam);
                    if (songs.Count() == 0)
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
                    var newArtist = CreateArtist(model.Artist.Naam);
                    if (albums.Count() == 0)
                    {

                        Album album = new Album()
                        {
                            Naam = model.Album.Naam,
                            Artist = model.Artist
                        };
                        _appContext.Albums.Add(album);
                        _appContext.SaveChanges();


                        Songs song = new Songs()
                        {
                            Title = model.Title,
                            Duration = model.Duration,
                            Artist = newArtist
                        };
                        _appContext.Songs.Add(song);
                        _appContext.SaveChanges();
                        ArtistAlbumSong Aas = new ArtistAlbumSong()
                        {
                            ArtistId = newArtist.Id,
                            SongId = song.Id,
                            AlbumId = album.Id
                        };

                        _appContext.ArtistAlbumSongs.Add(Aas);
                        _appContext.SaveChanges();
                    }
                    else
                    {

                        Songs song = new Songs()
                        {
                            Title = model.Title,
                            Duration = model.Duration,
                            Artist = newArtist
                        };
                        _appContext.Songs.Add(song);
                        _appContext.SaveChanges();
                        foreach (var item in albums)
                        {
                            if (item.Naam == model.Album.Naam && item.Artist.Naam == model.Artist.Naam)
                            {
                                ArtistAlbumSong Aas = new ArtistAlbumSong()
                                {
                                    ArtistId = newArtist.Id,
                                    SongId = song.Id,
                                    AlbumId = item.Id
                                };

                                _appContext.ArtistAlbumSongs.Add(Aas);
                                _appContext.SaveChanges();
                            }
                            
                                
                        }
                  
                    }

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
        public IActionResult AlbumCreate()
        {


            return View();
        }
        [HttpPost]
        public IActionResult AlbumCreate(MusicAlbumCreateViewModel model)
        {
            Album albumFromDb = _appContext.Albums.FirstOrDefault(a => a.Naam == model.Naam && a.Artist.Naam == model.Artist);
            Artist artistFromDb = _appContext.Artists.FirstOrDefault(a => a.Naam == model.Artist);
            IEnumerable<Songs> songsFromDb = _appContext.Songs.Where(s => s.Artist == artistFromDb);
            Artist newArtist = new Artist();

            if (!TryValidateModel(model))
            {
                return View(model);
            }
            if (albumFromDb == null)
            {
                if (artistFromDb == null)
                {
                    newArtist = CreateArtist(model.Artist.ToString());
                    CreateAlbum(model, newArtist);

                }
                else
                {
                    CreateAlbum(model, artistFromDb);

                }
            }




            return RedirectToAction("Music");
        }
        public IActionResult ArtistCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateArtist(MusicArtistCreateViewModel model)
        {
            Artist artist = new Artist()
            {
                Naam = model.Naam
            };
            _appContext.Artists.Add(artist);
            _appContext.SaveChanges();
            return RedirectToAction("Music");
        }
        public Artist CreateArtist(string naam)
        {
            Artist artist = new Artist()
            {
                Naam = naam
            };
            _appContext.Artists.Add(artist);
            _appContext.SaveChanges();
            return artist;
        }
        public async void CreateAlbum(MusicAlbumCreateViewModel model, Artist artist)
        {
            Album album = new Album()
            {
                Naam = model.Naam,
                Artist = artist
            };
            using (var memoryStream = new MemoryStream())
            {
                await model.Cover.CopyToAsync(memoryStream);
                album.Cover = memoryStream.ToArray();

            }
            _appContext.Albums.Add(album);
            _appContext.SaveChanges();

            ArtistAlbumSong artistAlbumSong = new ArtistAlbumSong()
            {
                AlbumId = album.Id,
                ArtistId = album.Artist.Id
            };
            _appContext.ArtistAlbumSongs.Add(artistAlbumSong);
            _appContext.SaveChanges();


        }

    }
}
