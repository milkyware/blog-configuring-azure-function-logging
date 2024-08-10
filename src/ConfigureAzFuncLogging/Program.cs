using ConfigureAzFuncLogging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddTransient<SampleService>();
    })
    //.ConfigureLogging((context, logging) =>
    //{
    //    logging.Services
    //        .Configure<LoggerFilterOptions>(options =>
    //        {
    //            // The Application Insights SDK adds a default logging filter that instructs ILogger to capture only Warning and more severe logs. Application Insights requires an explicit override.
    //            // Log levels can also be configured using appsettings.json. For more information, see https://learn.microsoft.com/en-us/azure/azure-monitor/app/worker-service#ilogger-logs
    //            var rule = options.Rules.FirstOrDefault(rule => rule.ProviderName
    //            == typeof(Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider).FullName);

    //            if (rule is not null)
    //                options.Rules.Remove(rule);
    //        });

    //    var section = context.Configuration.GetSection("AzureFunctionsJobHost:Logging");
    //    logging.AddConfiguration(section);
    //})
    .Build();

await host.RunAsync();
