
using GymManagerInfractracture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagerInfractracture.Seeders;
using GymManagerDomain.Interfaces;
using GymManagerInfractracture.Repositories;

namespace GymManagerInfractracture.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GymManagerDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("GymManager"),
                    b => b.MigrationsAssembly("GymManagerInfractracture")));

            services.AddScoped<GymManagerSeeder>();

            services.AddScoped<IGymManagerRepository, GymManagerRepository>();
        }
    }
}
