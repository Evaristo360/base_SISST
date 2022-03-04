using System;
using System.Globalization;

namespace SISST.Autenticacion.Helpers.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when username or password are invalid.
    /// </summary>
    /// <seealso cref="SISST.Autenticacion.Helpers.Exceptions.AppException" />
    public class InvalidUsernameOrPasswordException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUsernameOrPasswordException"/> class.
        /// </summary>
        public InvalidUsernameOrPasswordException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUsernameOrPasswordException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidUsernameOrPasswordException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUsernameOrPasswordException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public InvalidUsernameOrPasswordException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}