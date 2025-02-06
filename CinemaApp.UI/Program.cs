using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Data;
using CinemaApp.BL.Mapping;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using CinemaApp.BL.Services;
using CinemaApp.BL.Validators.Genre;
using FluentValidation;
using FluentValidation.AspNetCore;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(TotalMappProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMovieService, MovieService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
// mapper
builder.Services.AddAutoMapper(typeof(TotalMappProfile));
// validator
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddValidatorsFromAssembly(typeof(GenreCreateValidator).Assembly);

var validatorTypes = builder.Services.Where(s => s.ServiceType.IsGenericType
    && s.ServiceType.GetGenericTypeDefinition() == typeof(IValidator<>))
    .Select(s => s.ServiceType)
    .ToList();

Console.WriteLine("Registered Validators:");
foreach (var type in validatorTypes)
{
    Console.WriteLine(type);
}



// DB Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    //������� ����� ���� ���� ��������
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddEntityFrameworkStores<CinemaDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

await SeedService.SeedDatabase(app.Services);
// Auto migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CinemaDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();