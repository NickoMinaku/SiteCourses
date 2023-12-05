using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteCourses.Models;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
string? connectionString = builder.Configuration.GetConnectionString("SqlExpConnection");
builder.Services.AddDbContext<IDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IDBContext>();
builder.Services.AddSingleton<UserInit>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userInit = services.GetRequiredService<UserInit>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await userInit.InitAsync(userManager, roleManager, "NickoMinaku", "trueshchev@mail.ru", "Nicko_1408", "admin");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{action}",
    defaults: new { controller = "Home", action = "Index" });
app.Run();
