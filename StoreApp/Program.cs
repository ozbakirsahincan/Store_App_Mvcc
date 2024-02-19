using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

//MVC kullanacaksak AddControllersWithViews servisini ekliyoruz ...
builder.Services.AddControllersWithViews();
// Uygulamaya veritabanı kullanacağımızı belirtiyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    // Connection String i direkt vermek yerine appsettings.json altında verdiğimiz parametreyi veriyoruz.
    //builder.Configuration direk olarak appsettings e bağlanıyor.
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("StoreApp")
    );
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