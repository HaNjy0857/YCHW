using YCHW.Models;
using YCHW.Repositories.Interface;

namespace YCHW.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly List<Property> _properties = new();

        public async Task<Property?> GetPropertyByIdAsync(int id) => await Task.FromResult(_properties.FirstOrDefault(p => p.Id == id));
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync() => await Task.FromResult<IEnumerable<Property>>(_properties);
        public async Task AddPropertyAsync(Property property) { _properties.Add(property); await Task.CompletedTask; }
        public async Task UpdatePropertyAsync(Property property)
        {
            var existing = _properties.FirstOrDefault(p => p.Id == property.Id);
            if (existing != null) _properties[_properties.IndexOf(existing)] = property;
            await Task.CompletedTask;
        }
        public async Task DeletePropertyAsync(int id) { _properties.RemoveAll(p => p.Id == id); await Task.CompletedTask; }
    }
}
