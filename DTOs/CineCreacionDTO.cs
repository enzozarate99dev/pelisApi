using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pelisApi.DTOs
{
    public class CineCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 70)]
        public string Nombre {get; set; }
        //No se trae Point por ser un dato muy complejo. Conveneinte hacer un mapeo de lat y long => point
        [Range(-90,90)]
        public double Latitud {get; set; }
        [Range(-180,180)]

        public double Longitud {get; set; }

    }
}