using Microsoft.AspNetCore.Mvc;
using YCHW.Data;
using YCHW.Models;
using YCHW.Services.Interface;

namespace YCHW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertiesController(IPropertyService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            var properties = await _service.GetAllPropertiesAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _service.GetPropertyByIdAsync(id);
            return property == null ? NotFound() : Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            await _service.CreatePropertyAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] Property updatedProperty)
        {
            var property = await _service.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            property.Name = updatedProperty.Name;
            property.Location = updatedProperty.Location;
            property.Price = updatedProperty.Price;
            property.Status = updatedProperty.Status;
            property.Description = updatedProperty.Description;
            property.UpdatedAt = DateTime.Now;

            await _service.UpdatePropertyAsync(property);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _service.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            await _service.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}
