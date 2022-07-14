using System;
using Prometheus;

namespace Givt.Core.API.MiddleWare;

public class PrometheusRequestMiddleware
{
	private readonly RequestDelegate _next;

	public PrometheusRequestMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext httpContext)
    {
		var path = httpContext.Request.Path.Value;
		var method = httpContext.Request.Method;

		var counter = Metrics.CreateCounter("Api_Total_HTTP_Requests", "HTTP Requests Total", new CounterConfiguration
		{
			LabelNames = new[] {"path", "method", "status"} 
		});

		var statusCode = 200;

		try
        {
			await _next.Invoke(httpContext);
        }
		catch(Exception)
        {
			statusCode = 500;
			counter.Labels(path, method, statusCode.ToString()).Inc();
			throw;
        }

		if (!path.Equals("/metrics"))
        {
			statusCode = httpContext.Response.StatusCode;
			counter.Labels(path, method, statusCode.ToString()).Inc();
        }
    }
}

public static class RequestMiddlewareExtensions
{
	public static IApplicationBuilder UsePrometheusRequestMiddleware(this IApplicationBuilder builder)
    {
		return builder.UseMiddleware<PrometheusRequestMiddleware>();
    }
}
