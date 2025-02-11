using Microsoft.AspNetCore.Mvc;
using YCHW.Data;
using YCHW.Models;

namespace YCHW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProperties()
        {
            var properties = _context.Properties.ToList();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public IActionResult GetProperty(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        [HttpPost]
        public IActionResult CreateProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProperty(int id, Property updatedProperty)
        {
            var property = _context.Properties.Find(id);
            if (property == null) return NotFound();

            property.Name = updatedProperty.Name;
            property.Location = updatedProperty.Location;
            property.Price = updatedProperty.Price;
            property.Status = updatedProperty.Status;
            property.Description = updatedProperty.Description;
            property.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            var property = _context.Properties.Find(id);
            if (property == null) return NotFound();

            _context.Properties.Remove(property);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
