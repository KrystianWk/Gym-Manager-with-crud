using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager.GetGymManagerByEncodedName
{
    public class GetGymManagerByEncodedName : iRequest<GymManagerDto>

    {
        public string EncodedName {get;set;}        
        public GetGymManagerByEncodedName(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
   
}
