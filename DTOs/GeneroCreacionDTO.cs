using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using pelisApi.Validaciones;

namespace pelisApi.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }
    }
}