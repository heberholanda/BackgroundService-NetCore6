namespace WorkerService
{
    public class DailyTaskService : IHostedService
    {
        private readonly ILogger<DailyTaskService> _logger;

        public DailyTaskService(ILogger<DailyTaskService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var _timer = new Timer(
                RemoveInactiveAccounts,
                null,
                TimeSpan.Zero,
                TimeSpan.FromHours(24)
            );
            _logger.LogInformation("DailyTask  |  Starting Timer...");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void RemoveInactiveAccounts(object state)
        {
            _logger.LogInformation("DailyTask  |  RemoveInactiveAccounts");
        }
    }
}
