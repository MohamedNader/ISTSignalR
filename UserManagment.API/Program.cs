using IST.Entities.Core;
using IST.SQLContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UserManagment.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(option =>
{
});

#region DbContext
builder.Services.AddDbContext<UserManagmentContext>(options =>
    {
        options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration["Data:UserManagmentConnection:ConnectionString"]);
    });

builder.Services.AddIdentity<Users, Roles>((options) =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<UserManagmentContext>().AddDefaultTokenProviders();

#endregion

new DependencyResolutionFacade(builder.Services);
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
