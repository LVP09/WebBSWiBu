using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using WebBanSach.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false);
IConfiguration configuration = build.Build();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<dbcontext>(option => option.UseSqlServer("Data Source=LAPTOP-IOP6D48P\\SQLEXPRESS;Initial Catalog=WebBanSach;User ID=hung;Password=hung;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddAuthentication("MyCookie").AddCookie("MyCookie",config =>
{
    config.Cookie.Name = "MyCookie";
    config.LoginPath = "/Login/Login";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
        policy => policy.RequireClaim("Name", "Mr.Anderson"));
});
builder.Services.AddSession();
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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
