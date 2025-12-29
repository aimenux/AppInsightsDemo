using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace CoreLib.TelemetryInitializers;

public class UserTelemetryInitializer : ITelemetryInitializer
{
    private const string UserNameKey = "UserName";
    private const string MachineNameKey = "MachineName";

    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is MetricTelemetry)
        {
            return;
        }

        telemetry.Context.GlobalProperties.Add(UserNameKey, Environment.UserName);
        telemetry.Context.GlobalProperties.Add(MachineNameKey, Environment.MachineName);
    }
}