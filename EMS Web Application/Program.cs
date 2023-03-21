using EMS_Web_Application.Data;
using EMS_Web_Application.Repository;
using EMS_Web_Application.Repository.InitializedMemory;
using EMS_Web_Application.Repository.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();

builder.Services.AddSingleton<IDepartmentRepository, DepartmentInMemoryRepository>();

builder.Services.AddDbContext<EmployeeDbContext>();

builder.Services.AddScoped<EmployeeDbContext, EmployeeDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=ListAllEmployees}/{id?}");

app.Run();
