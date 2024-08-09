using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ConfigureAzFuncLogging.Functions
{
    public class TimerFunction(ILogger<TimerFunction> logger)
    {
        [Function(nameof(TimerFunction))]
        public async Task Run([TimerTrigger("0 0 * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            logger.LogInformation("Starting timer trigger");
            await Task.Delay(1000);
            logger.LogDebug("This is a debug message");
            await Task.Delay(1000);
            logger.LogTrace("This is a trace message");
        }
    }
}
