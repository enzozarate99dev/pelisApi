using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.Entidades
{
    public class PeliculasCines
    {
         public int PeliculaId { get; set; }
        public int CineId { get; set; }
        //propiedadesd de navegacion
        public Pelicula Pelicula { get; set; }
        public Cine Cine { get; set; }
    }
}