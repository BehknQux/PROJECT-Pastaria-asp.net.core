using Microsoft.EntityFrameworkCore;
using MvcWebAppProject.Helpers;
using MvcWebAppProject.Middlewares;
using MvcWebAppProject.Models;
using static System.TimeSpan;


var builder = WebApplication.CreateBuilder(args);

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = FromMinutes(30); // Session süresi
    options.Cookie.HttpOnly = true; // Cookie sadece HTTP üzerinden erişilebilir
    options.Cookie.IsEssential = true; // GDPR uyumluluğu için gereklidir
});

builder.Logging.ClearProviders();  // Varsayılan sağlayıcıları temizler
builder.Logging.AddConsole();     // Konsola log yazmayı etkinleştirir
builder.Logging.AddDebug();       // Debug penceresine log yazmayı etkinleştirir

// SQLite bağlantısını yapılandır
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session ve HttpContextAccessor servisini ekle
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

SessionHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseSession();
app.UseMiddleware<SessionMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();