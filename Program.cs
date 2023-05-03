using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShipBase.Interfaces;
using ShipBase.Models;
using ShipBase.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddTransient<IProductRepository, EFProductRepository>(); builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>(); builder.Services.AddScoped<Wishlist>(sp => SessionWishlist.GetWishlist(sp)); builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();



builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddScoped<Wishlist>(sp => SessionWishlist.GetWishlist(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddMemoryCache();

builder.Services.AddSession();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

var serviceProvider = builder.Services.BuildServiceProvider();
var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));

var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

//Getting the User to assign Admin role

var user = await userManager.FindByNameAsync("ShipbaseAdmin");

// Assign the "Admin" role to the user
if (user != null)
{
    await userManager.AddToRoleAsync(user, "Admin");
}




app.UseAuthentication();
app.UseAuthorization();



app.MapGet("/hi", () => "Hello!");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
app.MapControllerRoute(
    name: null,
    pattern: "{category}/Page{page:int}",
    defaults: new { Controller = "Product", action = "List" });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
app.MapControllerRoute(
    name: null,
    pattern: "Page{page:int}",
    defaults: new { Controller = "Product", action = "List", page = 1 });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
app.MapControllerRoute(
    name: null,
    pattern: "{category}",
    defaults: new { Controller = "Product", action = "List", page = 1 });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
app.MapControllerRoute(
    name: null,
    pattern: "",
    defaults: new { Controller = "Product", action = "List", page = 1 });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

/*
app.MapControllerRoute(
    name: null,
    pattern: "{controller=Product}/{action=Search}?{query=}",
    defaults: new { Controller = "Product", action = "Search" });
*/

app.UseSession();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();