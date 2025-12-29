[![.NET](https://github.com/aimenux/AppInsightsDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/AppInsightsDemo/actions/workflows/ci.yml)

# AppInsightsDemo
```
Logging into AppInsights
```

> 3 Logging methods implemented :
>
>> **(1)** Native : based only on microsoft libraries (code/file config based)
>>
>> **(2)** NLog : based on nlog libraries (xml file config based)
>>
>> **(3)** Serilog : based on serilog libraries (json file config based)
>
> 2 custom telemetry initializers implemented :
>> - `IpTelemetryInitializer`
>> - `UserTelemetryInitializer`

**`Tools`** : net 10, appinsights, nlog, serilog