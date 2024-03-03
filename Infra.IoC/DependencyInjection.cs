using Application.Interface;
using Application.Mapping;
using Application.Services;
using Domain.Interface;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IoC
{
    public static class DependencyInjection                                                                                                
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"
                ),b=>b.MigrationsAssembly(typeof( AppDbContext).Assembly.FullName)));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IContactBookRepository, ContactBookRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IContactBookService,ContactBookService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddAutoMapper(typeof(DomainToDTOMapping));

            return services;
        }
    }
}
