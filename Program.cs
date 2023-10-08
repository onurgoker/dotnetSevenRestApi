using MyMicroService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=GetUsers}/{id?}");

app.Run();