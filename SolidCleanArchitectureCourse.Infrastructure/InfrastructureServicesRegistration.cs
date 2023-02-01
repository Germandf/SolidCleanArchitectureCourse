using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolidCleanArchitectureCourse.Application.Contracts.Email;
using SolidCleanArchitectureCourse.Application.Contracts.Logging;
using SolidCleanArchitectureCourse.Application.Models.Email;
using SolidCleanArchitectureCourse.Infrastructure.EmailService;
using SolidCleanArchitectureCourse.Infrastructure.Logging;

namespace SolidCleanArchitectureCourse.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
