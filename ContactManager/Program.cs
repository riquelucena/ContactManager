using ContactManager.Business;
using ContactManager.Interfaces;
using ContactManager.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped <IContactRepository, ContactRepository>();
builder.Services.AddScoped <IAddContactsBusiness, AddContactsBusiness>();
builder.Services.AddScoped <IDeleteContactBusiness, DeleteContactBusiness>();
builder.Services.AddScoped <IGetAllContactsBusiness, GetAllContactsBusiness>();
builder.Services.AddScoped <IGetByIdContactBusiness, GetByIdContactBusiness>();
builder.Services.AddScoped <IUpdateContactBusiness, UpdateContactBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
