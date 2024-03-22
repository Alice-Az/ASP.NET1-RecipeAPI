using Microsoft.EntityFrameworkCore;
using RecipeDB.Models.Entities;
using RecipeDB.Repository.Interfaces;
using RecipeDB.Repository.Repos;
using RecipeDB.Services.Interfaces;
using RecipeDB.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RecipeDBContext>(
     options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=RecipeDB;Integrated Security=SSPI;TrustServerCertificate=True;")
 );
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRatingRepo, RatingRepo>();
builder.Services.AddScoped<IRatingService, RatingService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
