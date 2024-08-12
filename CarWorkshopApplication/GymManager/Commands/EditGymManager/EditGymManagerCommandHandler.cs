using GymManagerDomain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Commands.EditGymManager
{
 

    public class EditGymManagerCommandHandler : IRequestHandler<EditGymManagerCommand, Unit>
    {
        private readonly IGymManagerRepository _repository;

        public EditGymManagerCommandHandler(IGymManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditGymManagerCommand request, CancellationToken cancellationToken)
        {
            var gymManager = await _repository.GetByIdAsync(request.Id);

            if (gymManager == null)
            {
                throw new Exception("Gym Manager not found");
            }

            gymManager.Description = request.Description;
            gymManager.IsMembershipPaid = request.IsMembershipPaid;
            gymManager.Contact.PhoneNumber = request.PhoneNumber;
            gymManager.Contact.Address = request.Address;
            gymManager.Contact.City = request.City;
            gymManager.Contact.Email = request.Email;
            gymManager.Contact.PostalCode = request.PostalCode;

            await _repository.Commit();
            return Unit.Value;
        }
    }
}