using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using S.Core.Utils.ExceptionMiddleware;
using System.Text;
using T.Models.Profiles;
using T.Utility.Swagger;
using TechTrial.IOC;
using TechTrial.JWT.Model;
using TechTrial.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tech Trial Api", Version = "v1" });
    c.SchemaFilter<ExampleSchemaFilter>();

    // Configura el swagger para que muestre el botón de autorización en la interfaz de usuario
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Configura el swagger para que valide el token JWT
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Clase para registrar las dependencias
DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);

// Registra el automapper
builder.Services.AddAutoMapper(typeof(CandidatoProfile));

// configura los endpoints en minusculas para swagger
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Configura el servicio de autenticación con JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    };
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Configura la clase de Custom Exception Para personalizar las respuestas de error
builder.Services.AddControllers(options => options.Filters.Add<CustomExceptionFilter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

// configura el middleware de excepciones
app.UseMiddleware<MiddlewareApi>();
app.UseCors("MyPolicy"); //->Implementacion de cors

app.UseAuthorization();
app.MapControllers();

app.Run();
