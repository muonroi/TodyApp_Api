namespace RemindApp.Infrastructure;

public static class SerilogLoggerConfig
{
    public static ILogger CreateSerilogLogger(this IConfiguration configuration, IWebHostEnvironment env)
    {
        SerilogConfig? serilogConfig = configuration.GetSection("ElasticSearch").Get<SerilogConfig>() ?? throw new Exception("Serilog configuration not found.");
        if (string.IsNullOrEmpty(serilogConfig.Uri))
        {
            LoggerConfiguration bootstrapLoggerConfig = new LoggerConfiguration()
                                        .MinimumLevel.Information()
                                        .WriteTo.Console();

            return bootstrapLoggerConfig.CreateLogger();
        }

        ElasticsearchSinkOptions sinkOptions = ConfigureElasticsearchSink(serilogConfig, env);

        LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
             .MinimumLevel.Information()
             .ReadFrom.Configuration(configuration)
             .Enrich.FromLogContext()
             .Enrich.WithProperty("Environment", env.EnvironmentName)
             .Enrich.WithMachineName()
             .Enrich.WithProperty("UtcNow", DateTime.UtcNow);

        ConfigureFileSink(loggerConfiguration, serilogConfig);

        if (!string.IsNullOrEmpty(serilogConfig.Uri))
        {
            _ = loggerConfiguration.WriteTo.Elasticsearch(sinkOptions);
        }

        return loggerConfiguration.CreateLogger();
    }

    private static ElasticsearchSinkOptions ConfigureElasticsearchSink(SerilogConfig config, IWebHostEnvironment env)
    {
        Uri esUri = new(config.Uri);
        ElasticsearchSinkOptions sinkOptions = new(esUri)
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,

            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower()}-" +
                          "{Level:u3}-" +
                          $"{DateTime.UtcNow:yyyy-MM}",

            ModifyConnectionSettings = cs =>
            {
                if (!string.IsNullOrEmpty(config.Username) && !string.IsNullOrEmpty(config.Password))
                {
                    cs = cs.BasicAuthentication(config.Username, config.Password);
                }

                if (!string.IsNullOrEmpty(config.CaCertFileName))
                {
                    X509Certificate2? caCert = LoadCACertificate(config.CaCertFileName, env);
                    if (caCert != null)
                    {
                        cs = cs.ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) =>
                        {
                            return ValidateCertificateWithCustomCA(certificate, caCert);
                        });
                    }
                }

                return cs;
            }
        };

        return sinkOptions;
    }

    private static void ConfigureFileSink(LoggerConfiguration loggerConfiguration, SerilogConfig config)
    {
        string logPathFormat = Path.Combine(AppContext.BaseDirectory, "Logs", $"{DateTime.UtcNow:yyyyMMdd}", $"{config.LogName}.json");

        _ = loggerConfiguration.WriteTo.Async(a => a.File(
            path: logPathFormat,
            rollingInterval: RollingInterval.Day,
            outputTemplate: config.FileLogTemplate,
            shared: true,
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: config.FileSizeLimitBytes,
            retainedFileCountLimit: 31
        ));
    }



    private static X509Certificate2? LoadCACertificate(string caCertFileName, IWebHostEnvironment env)
    {
        string pathToCaCert = Path.Combine(env.WebRootPath ?? AppContext.BaseDirectory, caCertFileName);
        if (File.Exists(pathToCaCert))
        {
            return new X509Certificate2(pathToCaCert);
        }
        else
        {
            Console.WriteLine($"CA certificate file not found at '{pathToCaCert}'");
            return null;
        }
    }


    private static bool ValidateCertificateWithCustomCA(X509Certificate certificate, X509Certificate caCert)
    {
        X509Chain customChain = new();
        customChain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
        _ = customChain.ChainPolicy.CustomTrustStore.Add(caCert);
        customChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        if (certificate is not X509Certificate2 serverCert) return false;
        bool isValid = customChain.Build(serverCert);
        if (!isValid)
        {
            Console.WriteLine($"Server certificate validation failed using custom CA. Errors: {string.Join(", ", customChain.ChainStatus.Select(s => s.StatusInformation))}");
        }
        return isValid;
    }
}