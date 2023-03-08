using System.Text.RegularExpressions;

namespace SWAPI.Middlware
{
    public class ProtectMiddleware
    {
        private readonly RequestDelegate _next;
        const string TOKEN = "tokenkey";
        string customHeader = string.Empty;

        public ProtectMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(TOKEN, out var TokenKeyValue))
            {
                customHeader = TokenKeyValue;
            }

            bool isValidbearerGuid = bearerGuid(customHeader);


            if (!isValidbearerGuid)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("bearer guid was not provided ");
                return;
            }

            await _next(context);
        }
        public static bool bearerGuid(string value)
        {
            var regex = @"bearer\s[\d|a-f]{8}-([\d|a-f]{4}-){3}[\d|a-f]{12}";
            Match match = Regex.Match(value, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}
