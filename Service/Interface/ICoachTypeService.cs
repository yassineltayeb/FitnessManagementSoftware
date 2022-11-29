using Service.ViewModels.Common;

namespace Service.Interface;
public interface ICoachTypeService
{
    Task<List<KeyValuePairs>> GetCoachTypes();
}