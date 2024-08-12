using AutoMapper;
using GymManagerDomain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Queries.GetGymManagerById
{
    public class GetGymManagerByIdQueryHandler : IRequestHandler<GetGymManagerByIdQuery, GymManagerDto>
    {
        private readonly IGymManagerRepository _repository;
        private readonly IMapper _mapper;

        public GetGymManagerByIdQueryHandler(IGymManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GymManagerDto> Handle(GetGymManagerByIdQuery request, CancellationToken cancellationToken)
        {
            var gymManager = await _repository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<GymManagerDto>(gymManager);

            return dto;
           
            
        }
    }
}