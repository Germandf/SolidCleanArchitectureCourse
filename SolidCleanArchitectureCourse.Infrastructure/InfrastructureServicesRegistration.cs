using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolidCleanArchitectureCourse.Application.Contracts.Email;
using SolidCleanArchitectureCourse.Application.Models.Email;
using SolidCleanArchitectureCourse.Infrastructure.EmailService;

namespace SolidCleanArchitectureCourse.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
