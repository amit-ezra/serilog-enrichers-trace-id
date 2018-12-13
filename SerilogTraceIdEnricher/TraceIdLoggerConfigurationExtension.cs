using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
  public static class TraceIdLoggerConfigurationExtension
  {
    public static LoggerConfiguration WithTraceId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
    {
      if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
      return enrichmentConfiguration.With<TraceIdEnricher>();
    }
  }
}