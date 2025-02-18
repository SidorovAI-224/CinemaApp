using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Data;
using CinemaApp.BL.Mapping;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using CinemaApp.BL.Services;
using CinemaApp.BL.Validators.Genre;
using FluentValidation;
using FluentValidation.AspNetCore;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Repositories;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Repositories.MoviesCrewmates;

var builder = WebApplication.CreateBuilder(args);

// Automapper:
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(TotalMappProfile));

// Validators:
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddValidatorsFromAssembly(typeof(GenreCreateValidator).Assembly);

// Repositories:
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMovieCrewmateRepository, MovieCrewmateRepository>();

// Services:
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ICrewmateService, CrewmateService>();
builder.Services.AddScoped<IMovieCrewmateService, MovieCrewmateService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IAIService, AiService>();

builder.Services.AddHttpClient<OMDbService>(client =>
{
    client.BaseAddress = new Uri("http://www.omdbapi.com/");
});
builder.Services.AddSingleton<OMDbService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var apiKey = "d1d1c574";
    return new OMDbService(httpClient, apiKey);
});

builder.Services.AddScoped<SeedService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
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


// uncoment to load 100 random films to DB (takes time)
//using (var scope = app.Services.CreateScope())
//{
//    var seedData = scope.ServiceProvider.GetRequiredService<SeedService>();
//    await seedData.SeedRandomMoviesAsync(100);
//}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();