using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Extensions.Filters;
using System;

namespace Swashbuckle.Extensions
{
    public static class SwashbuckleExtensions
    {
        public static void AddAutoRestCompatible(this SwaggerGenOptions options)
        {
            options.SchemaFilter<AutoRestSchemaFilter>();
            options.OperationFilter<AutoRestOperationFilter>();
        }

        public static void MakeValueTypePropertiesRequired(this SwaggerGenOptions options)
        {
            options.SchemaFilter<RequireValueTypePropertiesSchemaFilter>(true);
        }

        public static void DefineOperationIdFromControllerNameAndActionName(this SwaggerGenOptions options)
        {
            options.OperationFilter<OperationIdFilter>();
        }
    }
}
