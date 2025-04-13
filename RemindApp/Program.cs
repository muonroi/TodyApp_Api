

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Assembly assembly = Assembly.GetExecutingAssembly();
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment webHostEnvironment = builder.Environment;

builder.AddAppConfiguration();
builder.AddAutofacConfiguration();


Log.Logger = configuration.CreateSerilogLogger(webHostEnvironment);
builder.Host.UseSerilog(Log.Logger, dispose: true);
Log.Information("Starting {ApplicationName} API up", builder.Environment.ApplicationName);

try
{
    IServiceCollection services = builder.Services;

    // Register services
    _ = services.AddApplication(assembly);
    _ = services.AddInfrastructure(configuration);
    _ = services.SwaggerConfig(builder.Environment.ApplicationName);
    _ = services.AddScopeServices(typeof(RemindAppDbContext).Assembly);
    _ = services.AddValidateBearerToken<MTokenInfo, Permission>(configuration);
    _ = services.AddDbContextConfigure<RemindAppDbContext, Permission>(configuration);
    _ = services.AddCors(configuration);
    _ = services.AddPermissionFilter<Permission>();
    services.RegisterService(configuration);


    WebApplication app = builder.Build();
    _ = app.UseCors("MAllowDomains");
    using (IServiceScope scope = app.Services.CreateScope())
    {
        RemindAppDbContext dbContext = scope.ServiceProvider.GetRequiredService<RemindAppDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    _ = app.UseDefaultMiddleware<RemindAppDbContext, Permission>();
    _ = app.AddLocalization(assembly);
    _ = app.UseRouting();
    _ = app.UseAuthentication();
    _ = app.UseAuthorization();
    _ = app.ConfigureEndpoints();
    _ = app.UseStaticFiles();
    _ = app.MigrateDatabase<RemindAppDbContext>();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception: {Message}", ex.Message);
}
finally
{
    Log.Information("Shut down {ApplicationName} complete", builder.Environment.ApplicationName);
    await Log.CloseAndFlushAsync();
}