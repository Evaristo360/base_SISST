using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SISST.Attributes
{
    public class FechaNoMayorAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string _otherPropertyName;
        public FechaNoMayorAttribute(string otherPropertyName, string errorMessage)
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
                                
                DateTime toValidate = (DateTime)value;
                DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                // if the end date is lower than the start date, than the validationResult will be set to false and return
                // a properly formatted error message
                var comparisonResult = DateTime.Compare(toValidate, referenceProperty);
                if (comparisonResult < 0) // reference is greater than toValidate
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

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-fechanomayor", ErrorMessage);
            context.Attributes.Add("data-val-fechanomayor-fechacomparar", _otherPropertyName);
        }

    }
}
