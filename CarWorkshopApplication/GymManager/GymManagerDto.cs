using GymManagerApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplication.GymManager
{
    public class GymManagerDto
    {
        public int Id { get; set; }
   //    [Required] 
     //   [StringLength(10, MinimumLength = 3)]
        public string? FirstName { get; set; }
       // [Required]
       // [StringLength(10, MinimumLength = 3, ErrorMessage = "Man we are not in China, type longer name")]
        public string? LastName { get; set; }
        //[Required]
        public Role Role { get; set; }
     //   [Required]
        public bool IsMembershipPaid { get; set; }
      //  [Required]
        public MembershipType MembershipType { get; set; }
         
   

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
      //  [Phone]
        public string? PhoneNumber { get; set; }
       // [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? EncodedName { get; set; }

        public bool isEditable { get; set; }    
    }
}
