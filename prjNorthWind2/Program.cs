using prjNorthWind2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IEmpRepository, EmpRepository>();
var app = builder.Build();
app.MapControllerRoute(
    name:"default",
    pattern:"{Controller=Home}/{Action=Index}/{id?}"
    );
//app.MapGet("/", () => "Hello World!");

app.Run();
