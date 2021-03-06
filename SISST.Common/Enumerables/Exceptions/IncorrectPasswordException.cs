using System;
using System.Globalization;

namespace Comunes.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when the password is incorrect.
    /// </summary>
    /// <seealso cref="Comunes.AppException" />
    public class IncorrectPasswordException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        public IncorrectPasswordException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public IncorrectPasswordException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public IncorrectPasswordException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}