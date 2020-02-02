# AppInsightsDemo
```
Logging into AppInsights
```

> 3 Logging methods :

>> (1) Native : based only on microsoft libraries
>>
>> Filters can be configured in [2 ways](https://github.com/MicrosoftDocs/azure-docs/blob/master/articles/azure-monitor/app/ilogger.md#control-logging-level) :
>> - JsonConfig : `"Logging": {"ApplicationInsights": {"LogLevel": {"NativeApi": "Trace"}}}`
>> - FluentConfig : `loggingBuilder.AddFilter<ApplicationInsightsLoggerProvider>(nameof(NativeApi), LogLevel.Trace)`
>>
>> (2) Nlog : based on nlog libraries (xml config based)
>>
>> (3) Serilog : based on serilog libraries (json config based)

> Custom telemetry initializers :
>> - `IpTelemetryInitializer`
>> - `UserTelemetryInitializer`

**`Tools`** : vs19, net core 3.1, nlog 4.9, serilog 3.2