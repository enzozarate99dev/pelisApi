using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pelisApi.Entidades;

namespace pelisApi
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Genero> Generos {get; set;}
        public DbSet<Actor> Actores {get; set;}

    }
}