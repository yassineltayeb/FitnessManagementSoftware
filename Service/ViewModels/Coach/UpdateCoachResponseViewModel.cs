namespace Service.ViewModels.Coach;
public class UpdateCoachResponseViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? GenderId { get; set; }
    public string Phone { get; set; }
    public List<int> CoachTypesIds { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public DateTime? DateOfBirth { get; set; }
}