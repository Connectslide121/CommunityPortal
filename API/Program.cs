using DataBaseConnection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//Connect IDataConnection to DataConnectionfi
builder.Services.AddScoped<IDataConnection, DataConnection>();

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