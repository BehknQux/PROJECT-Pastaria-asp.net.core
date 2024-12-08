using Microsoft.AspNetCore.Http;

namespace MvcWebAppProject.Helpers
{
    public static class SessionHelper
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Configure(IHttpContextAccessor? httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static int? GetUserId()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetInt32("userID");
        }

        public static string? GetUsername()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetString("username");
        }

        public static bool IsUserLoggedIn()
        {
            return GetUserId().HasValue;
        }
    }
}