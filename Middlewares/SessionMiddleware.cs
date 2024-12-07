using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MvcWebAppProject.Middlewares;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;

    public SessionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // İstisna rotalarını belirleyin
        var allowedPaths = new[] { "/login", "/register", "/css", "/js", "/images" };

        // Eğer istek bir istisna rotasına denk geliyorsa kontrol yapmadan devam et
        if (allowedPaths.Any(path => context.Request.Path.StartsWithSegments(path)))
        {
            await _next(context);
            return;
        }

        // Oturum kontrolü yap
        if (string.IsNullOrEmpty(context.Session.GetString("username")))
        {
            context.Response.Redirect("/login");
            return;
        }

        // Devam et
        await _next(context);
    }
}