using GymManagerDomain.Interfaces;
using GymManagerApplication.Entities;
using GymManagerInfractracture.Persistence;
using GymManagerInfractracture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerInfractracture.Repositories
{
    internal class GymManagerRepository : IGymManagerRepository
    {
        private readonly GymManagerDbContext _context;
        public GymManagerRepository(GymManagerDbContext context)
        {
            _context = context;
        }
        public async Task Create(GymManager gymManager)
        {
            _context.Add(gymManager);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GymManager>> GetAll()
          => await _context.GymManagers.ToListAsync();

        public Task<GymManager?> GetByEmail(string email)

            => _context.GymManagers.FirstOrDefaultAsync(x => x.Contact.Email.ToLower() == email.ToLower());
        
    }
}
