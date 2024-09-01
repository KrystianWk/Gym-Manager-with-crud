using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagerDomain.Interfaces;
using MediatR;
using AutoMapper;
using GymManagerApplication.ApplicationUser;
namespace GymManagerApplication.GymManager.Commands.CreateGymManager
{
    public class CreateGymManagerCommandHandler : IRequestHandler<CreateGymManagerCommands>
    {  
        private readonly IGymManagerRepository _gymManagerRepository;
        private readonly IMapper _mapper;   
        private readonly IUserContext _userContext;

        public CreateGymManagerCommandHandler(IGymManagerRepository gymManagerRepository, IMapper mapper, IUserContext userContext)
        {
            _gymManagerRepository = gymManagerRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateGymManagerCommands request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var gymManager = _mapper.Map<GymManagerApplication.Entities.GymManager>(request);
           
            gymManager.CreatedById = currentUser.Id;

            await _gymManagerRepository.Create(gymManager);
            return Unit.Value;
        }
    }
}
