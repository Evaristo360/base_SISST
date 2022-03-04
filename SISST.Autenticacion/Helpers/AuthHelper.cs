using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Comunes.Exceptions;

namespace SISST.Autenticacion.Helpers
{
    /// <summary>
    /// The authentication helper interface.
    /// </summary>
    public interface IAuthHelper
    {
        /// <summary>
        /// Gets the identifier of the user that made current request.
        /// It will use the first "Name" claim as identifier and cast it to GUID.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns>The identifier of the user that made current request.</returns>
        int GetUserId(ControllerBase controller);
    }

    /// <inheritdoc />
    public class AuthHelper : IAuthHelper
    {
        /// <inheritdoc />
        public int GetUserId(ControllerBase controller)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null) throw new UnauthorizedException();
            return int.Parse(identity.FindFirst(ClaimTypes.Name).Value);
        }
    }
}