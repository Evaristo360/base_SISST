using Comunes.Enumerables;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SISST.Attributes
{

    /// <summary>
    /// Compara dos valores considerando el tipo de operador.
    /// Importante, no valida el tipo de dato dado que la comparación es genérica
    /// </summary>
    /// <remarks>
    /// Desarrollado por
    ///     Juan Miguel González Castro
    ///     Septiembre 2021
    ///     basado en: www.codeproject.com/Tips/780992/Asp-Net-MVC-Custom-Compare-Data-annotation-with-Cl
    /// </remarks>
    public class CompareTwoPropertiesAttribute : ValidationAttribute, IClientModelValidator
    {

        #region Propiedades del validador
        /// <summary>
        /// Nombre de la propiedad con la cual se va a comparar
        /// </summary>
        public string OtherProperty { get; set; }
        /// <summary>
        /// Operador a considerar (GenericCompareOperator)
        /// </summary>
        public GenericCompareOperator Operador { get; set; }
        /// <summary>
        /// Mensaje a mostrar cuando no se cumpla la condición
        /// </summary>
        public string Message { get; set; }

        // No entieno por que pero aquí van
        private bool _checkedForLocalizer;
        private IStringLocalizer _stringLocalizer; // localization para remover posteriormente

        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null) return ValidationResult.Success;

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (otherPropertyValue == null) return ValidationResult.Success;

            if (value == null) return new ValidationResult("Dato requerido.");

            var valThis = (IComparable)value;
            var valOther = (IComparable)otherPropertyValue;
            bool noCumple = false;

            // validación respecto a la propiedad en comparación.
            switch (Operador)
            {
                case GenericCompareOperator.GreaterThan:
                    noCumple = valThis.CompareTo(valOther) <= 0;
                    break;
                case GenericCompareOperator.GreaterThanOrEqual:
                    noCumple = valThis.CompareTo(valOther) < 0;
                    break;

                case GenericCompareOperator.LessThan:
                    noCumple = valThis.CompareTo(valOther) >= 0;
                    break;

                case GenericCompareOperator.LessThanOrEqual:
                    noCumple = valThis.CompareTo(valOther) > 0;
                    break;
            }

            if (noCumple)
                return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
            else
                return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, Message, name);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            CheckForLocalizer(context);
            var errorMessage = GetErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val", "true"); //requiere validación
            MergeAttribute(context.Attributes, "data-val-comparetwoproperties", errorMessage);
            MergeAttribute(context.Attributes, "data-val-other", "#" + OtherProperty);
            MergeAttribute(context.Attributes, "data-val-compareoperator", Operador.ToString());
        }

        private string GetErrorMessage(string displayName)
        {
            if (_stringLocalizer != null &&
                !string.IsNullOrEmpty(ErrorMessage) &&
                string.IsNullOrEmpty(ErrorMessageResourceName) &&
                ErrorMessageResourceType == null)
            {
                return _stringLocalizer[ErrorMessage, displayName];
            }

            return FormatErrorMessage(displayName);
        }

        private void CheckForLocalizer(ClientModelValidationContext context)
        {
            if (!_checkedForLocalizer)
            {
                _checkedForLocalizer = true;

                var services = context.ActionContext.HttpContext.RequestServices;
                var options = services.GetRequiredService<IOptions<MvcDataAnnotationsLocalizationOptions>>();
                var factory = services.GetService<IStringLocalizerFactory>();

                var provider = options.Value.DataAnnotationLocalizerProvider;
                if (factory != null && provider != null)
                {
                    _stringLocalizer = provider(
                        context.ModelMetadata.ContainerType ?? context.ModelMetadata.ModelType,
                        factory);
                }
            }
        }

        private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }

}
