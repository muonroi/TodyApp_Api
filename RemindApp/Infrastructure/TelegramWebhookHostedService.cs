

namespace RemindApp.Infrastructure;

public class TelegramWebhookHostedService(IServiceProvider serviceProvider, IConfiguration configuration) : IHostedService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly string _webhookUrl = configuration["Telegram:WebhookUrl"] ?? string.Empty;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        ITelegramBotClientWrapper botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClientWrapper>();
        if (string.IsNullOrEmpty(_webhookUrl))
        {
            return;
        }
        await botClient.SetWebhookAsync(_webhookUrl, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
