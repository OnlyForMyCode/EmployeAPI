using Employee.Business.Mapper;
using Employee.Business.Repositories;
using Employee.Business.Repositories.IRepositories;
using Employee.Data;
using Employee.Data.Entities;
using Employee.WebServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Employe>, Repository<Employe>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
