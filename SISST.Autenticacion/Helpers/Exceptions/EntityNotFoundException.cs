using System;
using System.Globalization;

namespace SISST.Autenticacion.Helpers.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when the requested entity is not found.
    /// </summary>
    /// <seealso cref="SISST.Autenticacion.Helpers.Exceptions.AppException" />
    public class EntityNotFoundException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EntityNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public EntityNotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}