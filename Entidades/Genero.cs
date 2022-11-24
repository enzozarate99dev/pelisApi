using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using pelisApi.Validaciones;

namespace pelisApi.Entidades
{
    public class Genero : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        // [PrimeraLetraMayus]
        public string Nombre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre)) //verificar q nombre no es nulo
            {
                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula",
                    new string[] { nameof(Nombre) });
                }
            }
        }
    }
}