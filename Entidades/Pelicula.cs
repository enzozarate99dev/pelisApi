using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.Entidades
{
    public class Pelicula
    {
        public int Id {get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Titulo {get; set; }
        public string Resumen {get; set; }

        public string Trailer {get; set; }

        public bool EnCines {get; set; }

        public DateTime FechaLanzamiento {get; set; }

        public string Poster {get; set; }
        public List<PeliculasActores> PeliculasActores { get; set; }
        public List<PeliculasCines> PeliculasCines { get; set; }
        public List<PeliculasGeneros> PeliculasGeneros { get; set; }


    }
}