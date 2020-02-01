# AppInsightsDemo
```
Logging into AppInsights
```

> Methods :
>> Native : based on microsft libraries
>> - Microsoft.ApplicationInsights.AspNetCore
>> - Microsoft.Extensions.Logging.ApplicationInsights
>> Filters can be configured in [2 ways](https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/azure-monitor/app/ilogger.md#control-logging-level) :
>> - JsonConfig : `"Logging": {"ApplicationInsights": {"LogLevel": {"NativeApi": "Trace"}}}`
>> - FluentConfig : `loggingBuilder.AddFilter<ApplicationInsightsLoggerProvider>(nameof(NativeApi), LogLevel.Trace)`

