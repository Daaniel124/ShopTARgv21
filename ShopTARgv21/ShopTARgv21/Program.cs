using Microsoft.EntityFrameworkCore;
using ShopTARgv21.ApplicationServices.Services;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;

/*
 insert into Spaceship values
(NEWID(), 'Starship2', 'Cargo', 'SpaceX', 'EU', 215, 100, 5, 100, '2022-03-25', '2021-12-12', '2022-06-12', '2022-06-12')
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
