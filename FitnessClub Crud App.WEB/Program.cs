using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using FitnessClub.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PostgresContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRaspisanieService, RaspisanieService>();
builder.Services.AddScoped<IGruppaService, GruppaService>();
builder.Services.AddScoped<ITrenerService, TrenerService>();

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
