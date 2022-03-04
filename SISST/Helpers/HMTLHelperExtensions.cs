﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace SISST
{
    public static class HtmlHelpers
    {
        public static string isActive(this IHtmlHelper html, string controller = null, string action = null)
        {
            action = action.Contains("?") ? action.Substring(0, action.IndexOf("?")): action;

            string activeClass = "active"; // change here if you another name to activate sidebar items
            // detect current app state
            string actualAction = (string) html.ViewContext.RouteData.Values["action"];
            string actualController = (string) html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = actualController;

            if (String.IsNullOrEmpty(action))
                action = actualAction;

            return (controller == actualController && action == actualAction) ? activeClass : null;
        }
    }
}
