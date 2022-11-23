using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
