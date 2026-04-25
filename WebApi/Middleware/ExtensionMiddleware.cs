namespace WebApi.Middleware
{
    public static class ExtensionMiddleware
    {
                public static IApplicationBuilder UseHandelExpection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandelExpectionMiddleware>();
        }
    }
}
