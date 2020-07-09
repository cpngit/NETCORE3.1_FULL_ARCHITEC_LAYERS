using CPN.NetCore.Repository.Impl.Context;
using CPN.NetCore.Repository.Impl.Core;
using CPN.NetCore.Repository.Spec.Core.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CPN.NetCore.Service.Impl.Profiles;
using CPN.NetCore.Service.Spec;
using CPN.NetCore.Service.Impl;

namespace CPN.NetCore.CrossCutting
{
    public static class InjectorBootstrap
    {
        public static void AddServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
          
            services.AddAutoMapper(typeof(LnkProfileProfile).Assembly);

            RegisterDatabase(services, configuration);

            RegisterRepositories(services);

            RegisterServices(services);
           
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILnkProfileService, LnkProfileService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ICRUDDomainRepository<,>), typeof(CRUDDomainRepository<,>));
        }

        private static void RegisterDatabase(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CPN.NetCore.Repository.Impl")));
        }
    }
}
