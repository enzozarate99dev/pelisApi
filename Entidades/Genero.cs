using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using pelisApi.Validaciones;

namespace pelisApi.Entidades
{
    public class Genero 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }

       
    }
}