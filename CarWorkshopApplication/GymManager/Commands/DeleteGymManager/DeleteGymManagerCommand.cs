using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GymManagerApplication.GymManager.Commands.DeleteGymManager
{
    public class DeleteGymManagerCommand : IRequest<Unit>
    {
    public int Id { get; set; }

    public DeleteGymManagerCommand(int id)
    {
        Id = id;
    }
}
}