using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Students.APIServer.Extension;

/// <summary>
/// Swagger Extensions
/// </summary>
public class Swagger
{
    /// <summary>
    /// Фильтр свойств модели swagger, исключающий свойства - идентификаторы (ExcludeIdPropertyFilter)
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    public class ExcludeIdPropertyFilter<T> : ISchemaFilter
    {
        /// <summary>
        /// Применение фильтра
        /// </summary>
        /// <param name="model">Схема API</param>
        /// <param name="context">Контекст схемы</param>
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