using BackEnd.Entities;
using BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(
    options =>
    { options.IdleTimeout = TimeSpan.FromMinutes(20); }
    );

builder.Services.AddDbContext<BD_REDBOX_DISTRIBUIDORAContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DrixConnection")));
string connString = builder.Configuration.GetConnectionString("DrixConnection");
Util.ConnectionString = connString;


var app = builder.Build();

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=InicioSesion}/{id?}");

app.Run();
