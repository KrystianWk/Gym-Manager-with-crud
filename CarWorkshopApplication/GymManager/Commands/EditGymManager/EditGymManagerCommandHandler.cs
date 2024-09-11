using GymManagerApplication.ApplicationUser;
using GymManagerDomain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Commands.EditGymManager
{
 

    public class EditGymManagerCommandHandler : IRequestHandler<EditGymManagerCommand, Unit>
    {
        private readonly IGymManagerRepository _repository;
        private readonly IUserContext _userContext; 
        public EditGymManagerCommandHandler(IGymManagerRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditGymManagerCommand request, CancellationToken cancellationToken)
        {
            var gymManager = await _repository.GetByIdAsync(request.Id);

            var user =  _userContext.GetCurrentUser();
            var isEditable = user != null && (gymManager.CreatedById == user.Id || user.IsInRole("Moderator"));


            if (!isEditable)
            {
               return Unit.Value;
            }
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