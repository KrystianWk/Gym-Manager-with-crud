using GymManagerApplication.Mappings;
using GymManagerApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using GymManagerApplication.GymManager.Commands.CreateGymManager;
namespace GymManagerApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateGymManagerCommands));
            //services.AddScoped<IGymManagerServices, GymManagerServices>();

            services.AddAutoMapper(typeof(GymManagerMappingProfile));

            services.AddValidatorsFromAssemblyContaining<GymManagerDtoValidation>()
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();
        }
    }
}
