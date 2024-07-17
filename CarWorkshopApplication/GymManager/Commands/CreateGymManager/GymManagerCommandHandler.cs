using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagerDomain.Interfaces;
using MediatR;
using AutoMapper;
namespace GymManagerApplication.GymManager.Commands.CreateGymManager
{
    public class CreateGymManagerCommandHandler : IRequestHandler<CreateGymManagerCommands>
    {  
        private readonly IGymManagerRepository _gymManagerRepository;
        private readonly IMapper _mapper;   

        public CreateGymManagerCommandHandler(IGymManagerRepository gymManagerRepository, IMapper mapper)
        {
            _gymManagerRepository = gymManagerRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateGymManagerCommands request, CancellationToken cancellationToken)
        {
            var gymManager = _mapper.Map<GymManagerApplication.Entities.GymManager>(request);
            await _gymManagerRepository.Create(gymManager);
            return Unit.Value;
        }
    }
}
