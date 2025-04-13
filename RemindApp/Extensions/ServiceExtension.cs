


namespace RemindApp.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));

        services.AddSingleton<ITelegramBotClientWrapper, TelegramBotClientWrapper>();
        services.AddSingleton<IRetryPolicyProvider, DefaultRetryPolicyProvider>();
        services.AddSingleton<IMessageSplitter, PlainTextMessageSplitter>();
        services.AddSingleton<IHtmlMessageProcessor, HtmlMessageProcessor>();
        services.AddScoped(typeof(IAuthService<,>), typeof(AuthService<,>));
        return services;
    }
}
