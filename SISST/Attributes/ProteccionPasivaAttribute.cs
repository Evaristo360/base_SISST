using Comunes.Enumerables;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SISST.Attributes
{
    /// <summary>
    /// Valida los campos obligados en función del tpo de protección pasiva seleccionada
    /// </summary>
    /// <<remarks>
    /// Desarrollado por:
    ///     Juan Miguel González Castro
    ///     Octubre 2021
    /// </remarks>
    public class ProteccionPasivaAttribute : ValidationAttribute, IClientModelValidator
    {
        #region Propiedades del validador
        /// <summary>
        /// Nombre de la propiedad con la cual se va a comparar
        /// </summary>
        private string _otherProperty { get; set; }

        /// <summary>
        /// Tipo de compración 
        /// 0 para ponderación
        /// </summary>
        private enumProteccionPasiva[] _propertyToEval { get; set; }

        /// <summary>
        /// Mensaje de error
        /// </summary>
        private string _message { get; set; }

        #endregion

        public ProteccionPasivaAttribute(string otherProperty, enumProteccionPasiva[] propertyToEval, string errorMessage) : base(errorMessage)
        {
            _otherProperty = otherProperty;
            _propertyToEval = propertyToEval;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        /// <remarks>
        /// Importante
        ///     De cambiar lso valores enum así como los casos de la sentencia switch, se deben de homologar
        ///     los cambios realizados en customValidation.js
        /// </remarks>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            try
            {
                var otherProperty = validationContext.ObjectType.GetProperty(this._otherProperty);
                enumProteccionPasiva otherPropertyValue = (enumProteccionPasiva)(int)otherProperty.GetValue(validationContext.ObjectInstance, null);

                if (Array.IndexOf(_propertyToEval, otherPropertyValue) >= 0)
                {
                    switch (otherPropertyValue)
                    {
                        case enumProteccionPasiva.Diquedecontencion:
                        case enumProteccionPasiva.Fosacaptadoradehidrocarburo:
                        case enumProteccionPasiva.MamparaMuroseparador:
                            string material = (string)(value ?? ""); 
                            if (string.IsNullOrEmpty(material))
                                result = new ValidationResult(ErrorMessage);
                            break;

                        case enumProteccionPasiva.ExtractoresdeAire:
                            int operacion = value == null ? -1 : Convert.ToInt32(value);
                            if (operacion.Equals(-1))
                                result = new ValidationResult(ErrorMessage);
                            break;

                        case enumProteccionPasiva.Trincheraconbarreraantiflama:
                        case enumProteccionPasiva.Cablesdematerialretardantealfuego:
                        case enumProteccionPasiva.Selladodepasamurosconmaterialcontrafuego:
                        case enumProteccionPasiva.Charolasdecableadoconbarreraantiflama:
                            int porcentaje = value == null ? 0 : Convert.ToInt32(value);
                            if (porcentaje < 0 || porcentaje > 100)
                                result = new ValidationResult(ErrorMessage);
                            break;
                    }
                }
                return result;
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
            context.Attributes.Add("data-val-number", ErrorMessage);
            context.Attributes.Add("data-val-required", ErrorMessage);
            context.Attributes.Add("data-val-proteccionpasiva", ErrorMessage);
            context.Attributes.Add("data-val-proteccionpasiva-datovalidador", _otherProperty);
        }
    }

}
