using System;
using System.Data.Entity;
using System.Linq;

namespace lab4_films.DataModel
{
    public class EFDbcontext : DbContext
    {

        public EFDbcontext()
            : base("name=EFDbcontext")
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}