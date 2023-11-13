using BackESPDWebAPI.Middleware;

namespace BackESPDWebAPI.Extensions
{
    public static class ApiExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
