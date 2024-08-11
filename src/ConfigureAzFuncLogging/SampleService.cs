using Microsoft.Extensions.Logging;

namespace ConfigureAzFuncLogging
{
    public class SampleService
    {
        private readonly ILogger<SampleService> _logger;

        public SampleService(ILogger<SampleService> logger)
        {
            _logger = logger;
        }

        public async Task RunAsync()
        {
            _logger.LogInformation("Running sample service");
            await Task.Delay(500);
            _logger.LogDebug("This is a debug message");
            await Task.Delay(500);
            _logger.LogTrace("This is a trace message");
        }
    }
}
