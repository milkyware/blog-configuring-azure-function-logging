using Microsoft.Extensions.Logging;

namespace ConfigureAzFuncLogging
{
    public class SampleService(ILogger<SampleService> logger)
    {
        public async Task RunAsync()
        {
            logger.LogInformation("Running sample service");
            await Task.Delay(1000);
            logger.LogDebug("This is a debug message");
            await Task.Delay(1000);
            logger.LogTrace("This is a trace message");
        }
    }
}
