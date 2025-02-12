using YCHW.Models;

namespace YCHW.Services.Interface
{
    public interface IPropertyService
    {
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task CreatePropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
    }
}
