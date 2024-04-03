using ContactManager.Business;
using ContactManager.Interfaces;
using ContactManager.Repository;
using ContactManager.Service;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MariaDB");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Scoped);

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAddContactsBusiness, AddContactsBusiness>();
builder.Services.AddScoped<IDeleteContactBusiness, DeleteContactBusiness>();
builder.Services.AddScoped<IGetAllContactsBusiness, GetAllContactsBusiness>();
builder.Services.AddScoped<IGetByIdContactBusiness, GetByIdContactBusiness>();
builder.Services.AddScoped<IUpdateContactBusiness, UpdateContactBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<ContactDbContext>();
context.Database.Migrate();

app.Run();