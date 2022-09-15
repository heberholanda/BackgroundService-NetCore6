using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHostedService<TimedHostedService>();
        services.AddHostedService<DailyTaskService>();
        services.AddHostedService<DelayTimerService>();
    })
    .Build();

await host.RunAsync();
