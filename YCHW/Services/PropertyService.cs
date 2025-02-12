using YCHW.Models;
using YCHW.Repositories.Interface;
using YCHW.Services.Interface;

namespace YCHW.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        public PropertyService(IPropertyRepository repository) { _repository = repository; }

        public async Task<Property?> GetPropertyByIdAsync(int id) => await _repository.GetPropertyByIdAsync(id);
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync() => await _repository.GetAllPropertiesAsync();
        public async Task CreatePropertyAsync(Property property) { await _repository.AddPropertyAsync(property); }
        public async Task UpdatePropertyAsync(Property property) { await _repository.UpdatePropertyAsync(property); }
        public async Task DeletePropertyAsync(int id) { await _repository.DeletePropertyAsync(id); }
    }
}
