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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AfspeelLijstMovie>().HasKey(alm => new { alm.AfspeelLijstId, alm.MovieId });
            base.OnModelCreating(builder);
        }
    }
}
