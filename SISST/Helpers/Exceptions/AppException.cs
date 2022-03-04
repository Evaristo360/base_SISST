using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Helpers.Exceptions
{
    public class AppException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        public AppException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AppException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}