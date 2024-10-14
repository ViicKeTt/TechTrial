using T.Utility.Swagger;
using TechTrial.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Tech Trial Api", Version = "v1" });
    c.SchemaFilter<ExampleSchemaFilter>();
});

// Clase para registrar las dependencias
DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);

// Registra el automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configura los endpoints en minusculas para swagger
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
