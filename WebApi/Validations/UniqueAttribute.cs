using System.ComponentModel.DataAnnotations;
using WebApi.Context;

namespace WebApi.Validations
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) new ValidationResult(ErrorMessage ?? "value is null");
            var db = validationContext.GetService<ApiContext>();
            var entityType = validationContext.ObjectType;
            var propertyName = validationContext.MemberName;


            var query = db.GetType().GetMethod("Set", Type.EmptyTypes)?
                          .MakeGenericMethod(entityType)
                          .Invoke(db, null) as IQueryable;

            if (query == null) return ValidationResult.Success;

            var existingEntity = query.Cast<object>().AsEnumerable()
                .FirstOrDefault(e => e.GetType().GetProperty(propertyName!)?.GetValue(e)?.ToString() == value.ToString());

            if (existingEntity != null)
            {
                var keyName = db.Model.FindEntityType(entityType)!.FindPrimaryKey()!.Properties[0].Name;
                var existingId = entityType.GetProperty(keyName)!.GetValue(existingEntity);
                var currentId = entityType.GetProperty(keyName)!.GetValue(validationContext.ObjectInstance);

                if (existingId != null && !existingId.Equals(currentId))
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be unique.");
                }
            }
            return ValidationResult.Success;
        }
        
    }
}
