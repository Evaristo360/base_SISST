using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SISST.Attributes
{
    public class NullableFechaNoMayorAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string _otherPropertyName;
        public NullableFechaNoMayorAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this._otherPropertyName = otherPropertyName;
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                // Using reflection we can get a reference to the other date property, in this example the project start date
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this._otherPropertyName);
                // Let's check that otherProperty is of type DateTime as we expect it to be

                if (!otherPropertyInfo.PropertyType.Equals(new DateTime().GetType()))
                {
                    validationResult = new ValidationResult("Ha ocurrido un error al validad la propiedad. La propiedad a Comparar no es de tipo DateTime");
                    return validationResult;
                }

                //accept value as it can be null
                if (value == null || (DateTime)value == DateTime.MinValue)
                    return ValidationResult.Success;

                DateTime toValidate = (DateTime)value;
                DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                // if the end date is lower than the start date, than the validationResult will be set to false and return
                // a properly formatted error message
                if (toValidate.CompareTo(referenceProperty) < 1)
                {
                    validationResult = new ValidationResult(ErrorMessageString);
                }

                return validationResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (!context.Attributes.TryGetValue("value", out var dateValue) || dateValue == null)
                return; //nothing to add since its nullable 

            if (!context.Attributes.TryGetValue("data-val", out var dataVal) || String.IsNullOrWhiteSpace(dataVal))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-nullablefechanomayor", ErrorMessage);
            context.Attributes.Add("data-val-nullablefechanomayor-fechacomparar", _otherPropertyName);
        }

    }
}
