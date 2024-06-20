using CollegeBooks.Api.Authentication;
using CollegeBooks.Api.AuthWithIdentity;
using CollegeBooks.Data.Sql;
using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Services;
using DataModel;
using LinqToDB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LinqToDB.AspNet;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<ApiUser>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddApiEndpoints();

var connectionString = builder.Configuration.GetConnectionString("Database");

//Set LinqToDB.AspNet for get resources
builder.Services.AddLinqToDBContext<CollegeBooksDb>((provider, options) => options.UseSqlServer(connectionString));

//Set EntityFramework for build just AddIdentityCore service.
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapIdentityApi<ApiUser>();

app.MapControllers();

app.Run();
