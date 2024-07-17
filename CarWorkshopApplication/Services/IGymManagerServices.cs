
using GymManagerApplication.GymManager;

namespace GymManagerApplication.Services
{
    public interface IGymManagerServices
    {
        Task Create(GymManagerDto gymManager);
        Task<IEnumerable<GymManagerDto>> GetAll();
    }
}