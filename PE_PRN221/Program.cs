using Microsoft.EntityFrameworkCore;
using TreasureDAOs;
using TreasureRepos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ISeaAreaRepository, SeaAreaRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
// builder.Services.AddDbContext<TreasureOceanDb2024Context>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")
// ));

builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
