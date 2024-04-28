#pragma warning disable CS1591 

namespace Microsoft.AspNetCore.Builder
{
    public static class PathBaseExtension
    {
        public static IApplicationBuilder UseCustomPathBase(this IApplicationBuilder app, 
            string? pathBase)
        {
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            return app;
        }
    }
}

#pragma warning restore CS1591