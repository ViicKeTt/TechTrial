using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using T.Models.DTOs;

namespace T.Utility.Swagger
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CandidatoDto))
            {
                schema.Example = new OpenApiObject()
                {
                    ["id"] = new OpenApiInteger(0),
                    ["nombres"] = new OpenApiString("Esmerlin"),
                    ["apellidos"] = new OpenApiString("Borges Corporán"),
                    ["correoElectronico"] = new OpenApiString("netcore@hotmail.com"),
                    ["fechaNacimiento"] = new OpenApiString("2024-10-14T18:40:27.126Z"),
                    ["telefono"] = new OpenApiString("8498521000"),
                    ["fechaAplicacion"] = new OpenApiString("2024-10-14T18:40:27.126Z"),
                    ["puestoAplicado"] = new OpenApiString("Desarrollador"),
                };
            }
        }
    }
}
