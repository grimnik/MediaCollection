using System;
using System.Collections.Generic;
using System.Text;
using MediaCollection.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<AfspeelLijst> AfspeelLijsten { get; set; }
        public DbSet<AfspeelLijstMovie> AfspeelLijstMovies { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<ArtistAlbumSong> ArtistAlbumSongs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>().HasMany(a =>  a.Songs );
            builder.Entity<Songs>().HasMany(s => s.Albums);
            builder.Entity<ArtistAlbumSong>().HasKey(aas => new { aas.AlbumId, aas.ArtistId, aas.SongId });
            builder.Entity<AfspeelLijstMovie>().HasKey(alm => new { alm.AfspeelLijstId, alm.MovieId });
            base.OnModelCreating(builder);
        }
    }
}
