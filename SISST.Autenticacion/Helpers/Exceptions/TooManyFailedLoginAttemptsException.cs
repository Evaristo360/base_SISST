using System;
using System.Globalization;

namespace SISST.Autenticacion.Helpers.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when there were too many failed login attempts.
    /// </summary>
    /// <seealso cref="SISST.Autenticacion.Helpers.Exceptions.AppException" />
    public class TooManyFailedLoginAttemptsException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyFailedLoginAttemptsException"/> class.
        /// </summary>
        public TooManyFailedLoginAttemptsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyFailedLoginAttemptsException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TooManyFailedLoginAttemptsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyFailedLoginAttemptsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public TooManyFailedLoginAttemptsException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}