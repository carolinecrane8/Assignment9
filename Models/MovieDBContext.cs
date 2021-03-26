using System;
using Microsoft.EntityFrameworkCore;
//the context of the database is set here
namespace JoelHiltonsMovieCollectionEdit.Models

    {
        public class MovieDBContext : DbContext
        {
            public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
            {

            }

            public DbSet<Movies> Movies { get; set; }
        }
    }
