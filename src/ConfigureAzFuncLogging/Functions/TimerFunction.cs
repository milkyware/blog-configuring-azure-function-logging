using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ConfigureAzFuncLogging.Functions
{
    public class TimerFunction
    {
        private readonly ILogger<TimerFunction> _logger;
        private readonly SampleService _sampleService;

        public TimerFunction(ILogger<TimerFunction> logger, SampleService sampleService)
        {
            _logger = logger;
            _sampleService = sampleService;
        }

        [Function(nameof(TimerFunction))]
        public async Task Run([TimerTrigger("0 0 * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            await _sampleService.RunAsync();
        }
    }
}
