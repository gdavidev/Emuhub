﻿using System.Globalization;

namespace Emuhub.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(requestedCulture) && supportedCultures.Any(c => c.Name.Equals(requestedCulture)))
            {
                var culture = new CultureInfo(requestedCulture[..requestedCulture.IndexOf(',')]);

                SetCultures(culture);
            }
            else
            {
                SetCultures(new CultureInfo("en-US"));
            }

            await _next(context);
        }

        private static void SetCultures(CultureInfo culture)
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
