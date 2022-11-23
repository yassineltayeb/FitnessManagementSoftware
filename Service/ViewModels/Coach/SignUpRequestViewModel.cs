namespace Service.ViewModels.Coach;
public class SignUpRequestViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? GenderId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Password { get; set; }
}