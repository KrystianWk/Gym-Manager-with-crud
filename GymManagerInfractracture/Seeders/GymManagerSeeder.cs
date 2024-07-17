using GymManagerApplication.Entities;
using GymManagerInfractracture.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GymManagerInfractracture.Seeders
{
    public class GymManagerSeeder
    {
        private readonly GymManagerDbContext _dbContext;
        public GymManagerSeeder(GymManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.GymManagers.Any())
                {
                    _dbContext.GymManagers.AddRange(new List<GymManager>
                    {
                        new GymManager
                        {
                         FirstName = "Andrzej",
                         LastName = "Koza",
                         Role = Role.Trainer, // Zakładając, że Role.Trainer jest dostępną wartością enum Role
                         IsMembershipPaid = true, // Przykładowa wartość, zakładając, że karnet został opłacony
                         MembershipType = MembershipType.Premium, // Przykładowa wartość, zakładając, że jest to karnet Premium
                         JoinedAt = DateTime.UtcNow, // Data dołączenia
                         Contact = new GymManagerContact
                         {
                         City = "Warszawa", // Miasto   
                         PostalCode = "00-001", // Kod pocztowy
                         PhoneNumber = "123456789", // Numer telefonu
                         Email = "example@example.com", // Adres email
                         Address = "Przykładowa ulica 1", // Adres
                         },
                          Description = "Trener personalny z 5-letnim doświadczeniem", // Dodatkowy opis
                         CreatedAt = DateTime.UtcNow // Data utworzenia rekordu
                        }
                        
                    });
                   
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}