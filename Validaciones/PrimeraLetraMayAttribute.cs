using System.ComponentModel.DataAnnotations;

namespace PeliculasApi.Validaciones {
    public class PrimeraLetraMayAttribute: ValidationAttribute {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null || string.IsNullOrEmpty(value.ToString())) {
                return ValidationResult.Success;
            }

            var primeraLetra= value.ToString().Substring(0,1);

            if (primeraLetra != primeraLetra.ToUpper()) {
                return new ValidationResult("La primera letra debe ser mayúscula.");
            }

            return ValidationResult.Success;
        }

    }
}
