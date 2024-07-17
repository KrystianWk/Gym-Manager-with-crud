using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagerApplication.Entities
{
    [Table("GymManager")]
    public class GymManager
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public bool IsMembershipPaid { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime JoinedAt { get; set; }
  
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual GymManagerContact? Contact { get; set; } 
    }

    public enum Role
    {
        Trainer,
        GymMember,
        Receptionist
    }

    public enum MembershipType
    {
        Basic,
        Premium,
        Family
    }
}