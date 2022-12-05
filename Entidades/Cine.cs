using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace pelisApi.Entidades
{
    public class Cine
    {
        public int Id {get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Nombre {get; set; }
        public Point Ubicacion {get ;set ;}
        public List<PeliculasCines> PeliculasCines { get; set; }
   
    }
}