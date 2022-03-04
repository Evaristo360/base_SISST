using System;
using System.Globalization;

namespace SISST.Autenticacion.Helpers.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when there were too many failed attempts to change email address.
    /// </summary>
    /// <seealso cref="SISST.Autenticacion.Helpers.Exceptions.AppException" />
    public class TooManyChangeEmailAttemptsException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyChangeEmailAttemptsException"/> class.
        /// </summary>
        public TooManyChangeEmailAttemptsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyChangeEmailAttemptsException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TooManyChangeEmailAttemptsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyChangeEmailAttemptsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public TooManyChangeEmailAttemptsException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}