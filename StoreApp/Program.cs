using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

//MVC kullanacaksak AddControllersWithViews servisini ekliyoruz ...
builder.Services.AddControllersWithViews();
// Uygulamaya veritabanı kullanacağımızı belirtiyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    // Connection String i direkt vermek yerine appsettings.json altında verdiğimiz parametreyi veriyoruz.
    //builder.Configuration direk olarak appsettings e bağlanıyor.
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});


var app = builder.Build();
// Statik dosya aktif edilmesi için
app.UseStaticFiles();

//Auto Routing mekanizması kullanacaksak UseRouting kullanıyoruz
app.UseHttpsRedirection();
app.UseRouting();

// Default Controller Route belirliyoruz . 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();