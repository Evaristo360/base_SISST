using System;
using System.Globalization;

namespace Comunes.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when the action is forbidden due to the missing permissions.
    /// </summary>
    /// <seealso cref="Comunes.AppException" />
    public class ForbiddenException : AppException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        public ForbiddenException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ForbiddenException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public ForbiddenException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}