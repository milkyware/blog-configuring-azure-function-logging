using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ConfigureAzFuncLogging.Functions
{
    public class TimerFunction(ILogger<TimerFunction> logger, SampleService sampleService)
    {
        [Function(nameof(TimerFunction))]
        public async Task Run([TimerTrigger("0 0 * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            await sampleService.RunAsync();
        }
    }
}
