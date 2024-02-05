using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using proiect.Data; 
using proiect.Models; 
using proiect.Services.Implementations;
using proiect.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "produse",
    pattern: "Produse/{action=Index}/{id?}",
    defaults: new { controller = "Produse" });

app.MapControllerRoute(
    name: "categorie",
    pattern: "Categorie/{action=Index}/{id?}",
    defaults: new { controller = "Categorie" });

app.MapControllerRoute(
    name: "comenzi",
    pattern: "Comenzi/{action=Index}/{id?}",
    defaults: new { controller = "Comenzi" });

app.MapControllerRoute(
    name: "detaliiProdus",
    pattern: "DetaliiProdus/{action=Index}/{id?}",
    defaults: new { controller = "DetaliiProdus" });

app.MapControllerRoute(
    name: "detaliiComanda",
    pattern: "DetaliiComanda/{action=Index}/{id?}",
    defaults: new { controller = "DetaliiComanda" });

app.Run();
