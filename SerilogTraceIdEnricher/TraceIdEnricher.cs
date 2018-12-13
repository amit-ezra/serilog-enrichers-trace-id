using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

namespace Serilog.Enrichers
{
  public class TraceIdEnricher : ILogEventEnricher
  {
    public const string PropertyName = "TraceId";
    private readonly IHttpContextAccessor httpContextAccessor;

    public TraceIdEnricher()
      : this(new HttpContextAccessor())
    {
    }

    public TraceIdEnricher(IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
      var traceId = GetTraceId();
      if (!string.IsNullOrWhiteSpace(traceId))
      {
        var correlationIdProperty = new LogEventProperty(PropertyName, new ScalarValue(traceId));
        logEvent.AddOrUpdateProperty(correlationIdProperty);
      }
    }

    private string GetTraceId()
    {
      return httpContextAccessor?.HttpContext?.TraceIdentifier;
    }
  }
}
