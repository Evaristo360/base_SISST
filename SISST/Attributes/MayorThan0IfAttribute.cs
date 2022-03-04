using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SISST.Attributes
{
    /// <summary>
    /// Valida que el valor de la propiedad sea mayor que 0 cuando se tiene dependencia de un booleano
    /// </summary>
    public class MayorThan0IfAttribute : ValidationAttribute, IClientModelValidator
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        private string _dependentProperty { get; set; }
        private object _targetValue { get; set; }

        public MayorThan0IfAttribute(string dependentProperty, object targetValue, string errorMessage) : base(errorMessage)
        {
            _dependentProperty = dependentProperty;
            _targetValue = targetValue;
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validacion = ValidationResult.Success;
            var dependProperty = validationContext.ObjectType.GetProperty(_dependentProperty);
            if(dependProperty is null)
            {
                return new ValidationResult(FormatErrorMessage(_dependentProperty));
            }
            else
            {
                try
                {
                    bool dependPropertyValue = (bool)dependProperty.GetValue(validationContext.ObjectInstance, null);
                    int propertyValue = Convert.ToInt32(value);

                    if (dependPropertyValue && propertyValue <= 0)
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });

                    return validacion;

                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-mayorthan0if", ErrorMessage);
            context.Attributes.Add("data-val-mayorthan0if-datovalidador", _dependentProperty);
        }
    }
}
