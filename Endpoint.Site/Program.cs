using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Store.Application.Interfaces;
using Store.Application.Services.User.Commands.RegisterUser;
using Store.Application.Services.User.Queries.GetRoles;
using Store.Application.Services.User.Queries.GetUsers;
using Store.Application.Services.Users.Commands.ChangeUserStatus;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Commands.UpdateUser;
using Store.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IChangeUserStatusService,ChangeUserStatusService>();
builder.Services.AddScoped<IUpdateUserService,UpdateUserService>();

string connectionString = "Data Source=.; Initial Catalog=Store_WebShopDB; Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString),
    ServiceLifetime.Scoped // Note that Scoped is the default choice
                           // in AddDbContext. It is shown here only for
                           // pedagogic purposes.
    );




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

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();
