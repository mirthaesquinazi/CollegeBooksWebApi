using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CollegeBooks.Api.Authentication;
using CollegeBooks.Api.AuthWithIdentity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Option 1 :
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<ApiUser>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<ApiDbContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

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
