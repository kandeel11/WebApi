using System.ComponentModel.DataAnnotations;
using WebApi.Context;
// ضيف المكاتب دي لو مش موجودة
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Validations
{
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly Type _entityType;
        private readonly string _idPropertyName;

        public UniqueAttribute(Type entityType, string idPropertyName = "Id")
        {
            _entityType = entityType;
            _idPropertyName = idPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult(ErrorMessage ?? "value is null");

            var db = validationContext.GetService<ApiContext>();
            if (db == null) return new ValidationResult("Database context is missing.");

            var propertyName = validationContext.MemberName;

            var dbSet = db.GetType().GetMethod("Set", Type.EmptyTypes)!
                          .MakeGenericMethod(_entityType)
                          .Invoke(db, null) as IQueryable<object>;

            if (dbSet == null) return ValidationResult.Success;

            var existingEntity = dbSet.AsEnumerable()
                .FirstOrDefault(e => e.GetType().GetProperty(propertyName!)?.GetValue(e)?.ToString() == value.ToString());

            if (existingEntity != null)
            {
                var keyName = db.Model.FindEntityType(_entityType)!.FindPrimaryKey()!.Properties[0].Name;
                var existingId = _entityType.GetProperty(keyName)!.GetValue(existingEntity);

                var dtoIdProperty = validationContext.ObjectType.GetProperty(_idPropertyName);
                var currentId = dtoIdProperty?.GetValue(validationContext.ObjectInstance);

                if (existingId != null && !existingId.Equals(currentId))
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be unique.");
                }
            }
            return ValidationResult.Success;
        }
    }
}