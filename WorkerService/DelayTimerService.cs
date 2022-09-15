namespace WorkerService
{
    public class DelayTimerService : IHostedService
    {
        private readonly ILogger<DelayTimerService> _logger;

        public DelayTimerService(ILogger<DelayTimerService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
			TimeSpan interval = TimeSpan.FromHours(24);

			var nextRunTime = DateTime.Today.AddDays(1).AddHours(1);
			var curTime = DateTime.Now;
			var firstInterval = nextRunTime.Subtract(curTime);

			Action action = () =>
			{
				var taskDelay = Task.Delay(firstInterval);
				taskDelay.Wait();

				RemoveScheduledAccounts(null);

				var _timer = new Timer(
					RemoveScheduledAccounts,
					null,
					TimeSpan.Zero,
					interval
				);
			};

			Task.Run(action);
			_logger.LogInformation("DelayTimer  |  Starting Timer...");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
			_logger.LogInformation("DelayTimer  |  Stopping Timer...");
			return Task.CompletedTask;
        }

        private void RemoveScheduledAccounts(object state)
        {
            _logger.LogInformation("DelayTimer  |  RemoveInactiveAccounts");
        }
    }
}
