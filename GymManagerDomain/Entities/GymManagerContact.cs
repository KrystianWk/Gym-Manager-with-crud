using GymManagerApplication.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class GymManagerContact
{
    [Key]
    [ForeignKey("GymManager")]
    public int GymManagerId { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Address { get; set; }

    public virtual GymManager? GymManager { get; set; }
}