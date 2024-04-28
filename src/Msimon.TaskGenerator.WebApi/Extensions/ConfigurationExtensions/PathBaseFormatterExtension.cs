#pragma warning disable CS1591 

namespace Microsoft.Extensions.Configuration
{
    public static class PathBaseFormatterExtension
    {
        public static string? GetPathBase(this IConfiguration configuration)
        {
            var pathBase = configuration.GetValue<string>("PATH_BASE");

            if (!string.IsNullOrEmpty(pathBase) && !pathBase.StartsWith('/'))
                pathBase = $"/{pathBase}";
            
            return pathBase;
        }
    }
}

#pragma warning restore CS1591 

