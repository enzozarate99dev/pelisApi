using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pelisApi.Utilidades;

namespace pelisApi.DTOs
{
    public class PeliculaCreacionDTO
    {
        
        [Required]
        [StringLength(maximumLength: 200)]
        public string Titulo {get; set; }
        public string Resumen {get; set; }

        public string Trailer {get; set; }

        public bool EnCines {get; set; }

        public DateTime FechaLanzamiento {get; set; }
        public IFormFile Poster {get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CinesIds { get; set; }
        
        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculaCreacionDTO>>))]
        public List<ActorPeliculaCreacionDTO> Actores { get; set; } 
    }
}