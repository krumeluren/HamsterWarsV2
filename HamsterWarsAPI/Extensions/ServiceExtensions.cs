using Core.Contracts.Repo.Contracts;
using Core.Contracts.Service.Contracts;
using Core.Shared.DataTransferObject.Battle;
using Core.Shared.DataTransferObject.Hamster;
using Infrastructure.Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Presentation.HamsterWarsAPI.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepoManager, RepoManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RepoContext>(options => options.UseSqlServer(config.GetConnectionString("sqlConnection")));
    }

    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder)
    {
        builder.AddMvcOptions(config =>
            config.OutputFormatters.Add(new CsvOutputFormatter<HamsterGetDto>())
            );
        builder.AddMvcOptions(config =>
            config.OutputFormatters.Add(new CsvOutputFormatter<BattleGetDto>())
            );
        return builder;
    }
}
