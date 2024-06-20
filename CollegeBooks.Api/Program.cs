using CollegeBooks.Api.Authentication;
using CollegeBooks.Api.AuthWithIdentity;
using CollegeBooks.Api.Filters;
using CollegeBooks.Data.Sql.Repositories;
using CollegeBooks.Logic.Services;
using DataModel;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static LinqToDB.Tools.DataProvider.SqlServer.Schemas.ServiceBrokerSchema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMvcCore(options =>{options.Filters.Add<ValidationFilter>();});

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
