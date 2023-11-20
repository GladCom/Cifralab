using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Students.APIServer.Extension;

/// <summary>
/// Swagger Extensions
/// </summary>
public class Swagger
{
    /// <summary>
    /// ExcludeIdPropertyFilter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcludeIdPropertyFilter<T> : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            var type = context.Type;
            if (type == typeof(T) && model.Properties != null)
            {
                var idProperty = model.Properties.FirstOrDefault(p => p.Key.Equals("Id", StringComparison.OrdinalIgnoreCase));
                if (!idProperty.Equals(default(KeyValuePair<string, OpenApiSchema>)))
                {
                    model.Properties.Remove(idProperty.Key);
                }
            }
        }
    }
}