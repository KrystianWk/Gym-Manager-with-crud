using GymManagerApplication.Mappings;
using GymManagerApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using GymManagerApplication.GymManager.Commands.CreateGymManager;
using GymManagerApplication.GymManager.Commands.DeleteGymManager;
using GymManagerDomain.Interfaces;
using MediatR;
using AutoMapper;
using System.Reflection;
using GymManagerApplication.ApplicationUser;

namespace GymManagerApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateGymManagerCommands).Assembly);
            //services.AddScoped<IGymManagerServices, GymManagerServices>();
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new GymManagerMappingProfile(userContext));
            }).CreateMapper()
            );
          //  services.AddAutoMapper(typeof(GymManagerMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateGymManagerCommandHandler>()
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();
        }
    }
}
