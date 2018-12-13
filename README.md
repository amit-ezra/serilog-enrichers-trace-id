# serilog-enrichers-trace-id
Enrich serilog events with TraceIdentifier from HttpContext

## Installation:

Install-Package TODO

## Usage:

Add enricher to your `LoggerConfiguration`:

```
Log.Logger = new LoggerConfiguration()
    .Enrich.WithTraceId()
    // ...other configuration...
    .CreateLogger();
```

Register `HttpContextAccessor` in DI (as `Singleton`). One options is: 

```
public void ConfigureServices(IServiceCollection services)
{
     ...
     services.AddHttpContextAccessor();
```

This will add a `TraceId` property to log events.
