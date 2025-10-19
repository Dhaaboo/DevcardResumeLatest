using DevcardResume.Data;
using DevcardResume.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var _blder = WebApplication.CreateBuilder(args);
var _Srvc = _blder.Services;

// Add services to the container.
var Ctr = _blder.Configuration.GetConnectionString("MYRDBCS") ?? throw new InvalidOperationException("Connection string 'In Your Project' not found.");
_Srvc.AddDbContext<APPDBC>(options =>
    options.UseSqlServer(Ctr));
_Srvc.AddDatabaseDeveloperPageExceptionFilter();

_Srvc.AddDefaultIdentity<DevResumeUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<APPDBC>();
_Srvc.AddControllersWithViews();

var app = _blder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
