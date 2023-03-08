using SWAPI.Middlware;

namespace SWAPI
{
    public static class StarwarMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            builder.UseWhen(context => (context.Request.Path.StartsWithSegments("/swapi/public")),
                    appBuilder =>
                        {
                            appBuilder.UseMiddleware<PublicMiddleware>();

                        });


            builder.UseWhen(context => (context.Request.Path.StartsWithSegments("/swapi/protected")),
                     appBuilder =>
                     {
                         appBuilder.UseMiddleware<ProtectMiddleware>();

                     });

            return builder;
        }
    }
}

