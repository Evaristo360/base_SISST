using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SISST.Attributes
{
    public class RequiredIfAttribute : ValidationAttribute, IClientModelValidator
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        private string _otherProperty { get; set; }
        private object _targetValue { get; set; }

        public RequiredIfAttribute(string otherProperty, object targetValue, string errorMessage): base(errorMessage)
        {
            _otherProperty = otherProperty;
            _targetValue = targetValue;
            ErrorMessage = errorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherProperty);
            if (otherProperty != null)
            {
                var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

                if (otherPropertyValue == null)
                    return ValidationResult.Success;

                else if ((otherPropertyValue == null && _targetValue == null) || (otherPropertyValue.Equals(_targetValue)))
                {
                    if (!_innerAttribute.IsValid(value))
                        return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
                return ValidationResult.Success;
            }
            else
                return new ValidationResult(FormatErrorMessage(_otherProperty));
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            string targetValue = string.Empty;
            Type typeTargetVale = _targetValue.GetType();

            if (typeTargetVale.Equals(typeof(string)))
                targetValue = Convert.ToString(_targetValue);
            else if (typeTargetVale.Equals(typeof(bool)))
                targetValue = Convert.ToBoolean(_targetValue).ToString();
            else if (typeTargetVale.Equals(typeof(int)))
                targetValue = Convert.ToInt32(_targetValue).ToString();
            else if (typeTargetVale.Equals(typeof(float)))
                targetValue = Convert.ToDouble(_targetValue).ToString();
            else if (typeTargetVale.Equals(typeof(DateTime)))
                targetValue = Convert.ToDateTime(_targetValue).ToString();

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-requiredif", ErrorMessage);
            context.Attributes.Add("data-val-requiredif-datovalidador", _otherProperty);
            context.Attributes.Add("data-val-requiredif-valordatovalidador", targetValue);

            context.Attributes.Add("data-val-required", ErrorMessage);
        }
    }
}
