using Opah.Application.Interfaces;
using Opah.Domain.Settings;
using Opah.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Opah.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
        }
    }
}
