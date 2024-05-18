using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HerramientasProgFinal.Data;
using HerramientasProgFinal.Services;
using HerramientasProgFinal.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CitacionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CitacionContext") 
    ?? throw new InvalidOperationException("Connection string 'CitacionContext' not found.")));

// Add services to the container.
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CitacionContext>();

builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<IConsultorioService, ConsultorioService>();
// builder.Services.AddScoped<IRolesService, RolesService>();
// builder.Services.AddScoped<ICitacionService, CitacionService>();
// builder.Services.AddScoped<IDoctorService, DoctorService>();
// builder.Services.AddScoped<IPacienteService, PacienteService>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
