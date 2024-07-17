using AutoMapper;
using GymManagerDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Queries.GetAllGymMenagers
{
    public class GetAllGymManagerQueryHandler : IRequestHandler<GetAllGymManagerQuery, IEnumerable<GymManagerDto>>
        
    {   private readonly IGymManagerRepository _gymManagerRepository;
        private readonly IMapper _mapper;
        public GetAllGymManagerQueryHandler(IGymManagerRepository gymManagerRepository, IMapper mapper)
        {
            _gymManagerRepository = gymManagerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GymManagerDto>> Handle(GetAllGymManagerQuery request, CancellationToken cancellationToken)
        {
            var GymManagers = await _gymManagerRepository.GetAll();
            return _mapper.Map<IEnumerable<GymManagerDto>>(GymManagers);
        }
    }
}
