using Core.UserClasses;
using DataBaseConnection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();

IConfigurationRoot Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Get the connection string from the environment variable
var connectionString = Environment.GetEnvironmentVariable("CommunityConnection");

// Set the MySQL Server Version
var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));//*********There might be a way to detect automatically
                                                                  //(like "ServerVersion.AutoDetect") but I couldn't figure it out

// Configure the DbContext with the connection string
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<DataContext>();

//Connect IDataService to DataService
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddScoped<IEventsService, EventsService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/logout", async (SignInManager<User> signInManager,
    [FromBody] object empty) =>
{
    if (empty != null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.Unauthorized();
})
.RequireAuthorization();


app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
