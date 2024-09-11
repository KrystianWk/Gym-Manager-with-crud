using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymManagerApplication.GymManager;
using GymManagerApplication.Entities;
using GymManagerApplication.GymManager.Commands.EditGymManager;
using GymManagerApplication.ApplicationUser;

namespace GymManagerApplication.Mappings
{
    public class GymManagerMappingProfile : Profile
    {
        public GymManagerMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<GymManagerDto, GymManagerApplication.Entities.GymManager>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => new GymManagerContact()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Email = src.Email,
                }));
              
            CreateMap<GymManagerApplication.Entities.GymManager, GymManagerDto>()
                .ForMember(dest => dest.isEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator")) ))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Contact.City))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Contact.PostalCode))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email));

            CreateMap<GymManagerDto, EditGymManagerCommand>();
        }
    }
}
