using System;
using GymManagerApplication.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerDomain.Interfaces
{
    public interface IGymManagerRepository
    {
        Task Create(GymManager gymManager);
        Task<GymManager?> GetByEmail(string email);
        Task<IEnumerable<GymManager>> GetAll();
    }
}
