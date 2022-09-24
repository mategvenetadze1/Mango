using Mango.UI.Web.Models.Configs;
using Mango.UI.Web.Services.Implementations;
using Mango.UI.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

ServiceUrls.ProductUrl = configuration.GetSection("ServiceUrls").GetSection("ProductUrl").Value;

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, ProductService>();

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
