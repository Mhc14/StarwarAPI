using Microsoft.AspNetCore.Http.Extensions;
using System.Text.RegularExpressions;

namespace SWAPI.Middlware
{
    public class PublicMiddleware
    {
        private readonly RequestDelegate _next;
        const string APIKEY = "x-api-key";
        string customHeader = string.Empty;
        public PublicMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(APIKEY, out var ApiKeyvalue))
            {
                customHeader = ApiKeyvalue;
            }
            bool isValidGuid = IsGuid(customHeader);
            var url = context.Request.GetDisplayUrl();
            if (!isValidGuid)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }
            await _next(context);
        }

        public static bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
        public static bool bearerGuid(string value)
        {
            var regex = @"bearer\s[\d|a-f]{8}-([\d|a-f]{4}-){3}[\d|a-f]{12}";
            Match match = Regex.Match(value, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}