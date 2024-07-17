using GymManagerDomain.Interfaces;
using GymManagerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagerApplication;
using GymManagerApplication.GymManager;
using AutoMapper;
namespace GymManagerApplication.Services
{
    public class GymManagerServices : IGymManagerServices
    {
        private readonly IGymManagerRepository _gymManagerRepository;
        private readonly IMapper _mapper;

        public GymManagerServices(IGymManagerRepository gymManagerRepository, IMapper mapper)
        {
            _gymManagerRepository = gymManagerRepository;
            _mapper = mapper;
        }
        public async Task Create(GymManagerDto gymManagerDto)
        {
     //      var gymManager = _mapper.Map<GymManagerApplication.Entities.GymManager>(gymManagerDto);
   //         await _gymManagerRepository.Create(gymManager);
        }
        public async Task<IEnumerable<GymManagerDto>> GetAll()
        {
    //        var GymManagers = await _gymManagerRepository.GetAll();
      //      return _mapper.Map<IEnumerable<GymManagerDto>>(GymManagers);
        }
    }
}
