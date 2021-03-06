using Comunes.Health;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SISST.Catalog
{

    public static class HealthCheckExtensions
    {
        public static IEndpointConventionBuilder MapCustomHealthChecks(this IEndpointRouteBuilder endpoints, string serviceName)
        {

            return endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    await WriteResponse(context, report, serviceName);
                }
            });
        }

        internal static Task WriteResponse(HttpContext context, HealthReport report, string serviceName)
        {
            var result = JsonConvert.SerializeObject(
                        new HealthResult
                        {
                            Name = serviceName,
                            Status = report.Status.ToString(),
                            Duration = report.TotalDuration,
                            Info = report.Entries.Select(e => new HealthInfo
                            {
                                Key = e.Key,
                                Description = e.Value.Description,
                                Duration = e.Value.Duration,
                                Status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                Error = e.Value.Exception?.Message
                            }).ToList()
                        },
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(result);
        }
    }
}
