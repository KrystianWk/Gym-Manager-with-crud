using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.Queries.GetAllGymMenagers
{
    public class GetAllGymManagerQuery : IRequest<IEnumerable<GymManagerDto>>
    {
    }
}
