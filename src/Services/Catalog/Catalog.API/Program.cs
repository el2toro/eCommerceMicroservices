var builder = WebApplication.CreateBuilder(args);

//Add services to the container

var app = builder.Build();

//Configure HTTP requests pipeline

app.Run();
