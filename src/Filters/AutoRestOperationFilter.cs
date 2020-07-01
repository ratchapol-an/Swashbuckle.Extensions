using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Swashbuckle.Extensions.Filters
{
    public class AutoRestOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var errorResponses = operation.Responses.Where(o =>
            o.Key.StartsWith("4", StringComparison.InvariantCultureIgnoreCase)
            || o.Key.StartsWith("5", StringComparison.InvariantCultureIgnoreCase));
            foreach (var response in errorResponses)
            {
                response.Value.Extensions.Add("x-ms-error-response", new OpenApiBoolean(true));
            }
        }
    }
}
