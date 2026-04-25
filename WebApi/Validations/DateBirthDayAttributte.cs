using System.ComponentModel.DataAnnotations;

namespace WebApi.Validations
{
    public class DateBirthDayAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var expAge = DateTime.Now.Year - (value as DateTime?)!.Value.Year;
            var Age = validationContext.ObjectInstance.GetType().GetProperty("Age")?.GetValue(validationContext.ObjectInstance);

            if ((Age as int?)==(expAge as int?))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "Age does not match the date of birth.");
            }
        }
    }
}
