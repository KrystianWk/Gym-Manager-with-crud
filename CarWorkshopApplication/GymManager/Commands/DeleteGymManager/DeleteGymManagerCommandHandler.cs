using GymManagerDomain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Commands.DeleteGymManager
{
    public class DeleteGymManagerCommandHandler : IRequestHandler<DeleteGymManagerCommand, Unit>
    {
        private readonly IGymManagerRepository _repository;

        public DeleteGymManagerCommandHandler(IGymManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteGymManagerCommand request, CancellationToken cancellationToken)
        {
            var gymManager = await _repository.GetByIdAsync(request.Id);

            if (gymManager == null)
            {
                throw new Exception("Gym Manager not found");
            }

            _repository.Delete(gymManager);
            await _repository.Commit();

            return Unit.Value;
        }
    }
}