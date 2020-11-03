using Microsoft.AspNetCore.Builder;

namespace VosakOrgWeb.Middleware
{
    public static class VosakOrgMiddleware
    {
            public static void RegisterCustomMiddlewares(this IApplicationBuilder app)
            {
                app.UseMiddleware<CustomExceptionMiddleware>();
            }
    }
}