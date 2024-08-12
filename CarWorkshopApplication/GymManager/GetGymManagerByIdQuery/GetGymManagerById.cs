using MediatR;

namespace GymManagerApplication.GymManager.Queries.GetGymManagerById
{
    public class GetGymManagerByIdQuery : IRequest<GymManagerDto>
    {
        public int Id { get; set; }

        public GetGymManagerByIdQuery(int id)
        {
            Id = id;
        }
    }
}