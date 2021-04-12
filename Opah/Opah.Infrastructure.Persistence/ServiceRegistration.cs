using Opah.Application.Interfaces;
using Opah.Application.Interfaces.Repositories;
using Opah.Infrastructure.Persistence.Contexts;
using Opah.Infrastructure.Persistence.Repositories;
using Opah.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opah.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IClienteRepositoryAsync, ClienteRepositoryAsync>();
            services.AddTransient<IClienteEnderecoRepositoryAsync, ClienteEnderecoRepositoryAsync>();
            services.AddTransient<IEnderecoRepositoryAsync, EnderecoRepositoryAsync>();
            #endregion
        }
    }
}
