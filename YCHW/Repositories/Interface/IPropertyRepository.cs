using YCHW.Models;

namespace YCHW.Repositories.Interface
{
    public interface IPropertyRepository
    {
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task AddPropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
    }
}
