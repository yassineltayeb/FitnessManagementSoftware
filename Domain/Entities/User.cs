using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public abstract class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [ForeignKey(nameof(Gender))]
    public int? GenderId { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [ForeignKey(nameof(Country))]
    public int? CountryId { get; set; }
    public Country Country { get; set; }
    [ForeignKey(nameof(City))]
    public int? CityId { get; set; }
    public City City { get; set; }
    public long CreatedAt { get; set; }
    public long UpdatedAt { get; set; }
    public ICollection<CoachMember> CoachMember { get; set; }
    public int UserTypeId { get; set; }
}
