using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using YCHW.Controllers;
using YCHW.Models;
using YCHW.Services.Interface;

namespace YCHW.Tests
{
    public class PropertiesControllerTests
    {
        private readonly Mock<IPropertyService> _mockService;
        private readonly PropertiesController _controller;

        public PropertiesControllerTests()
        {
            _mockService = new Mock<IPropertyService>();
            _controller = new PropertiesController(_mockService.Object);
        }

        [Fact]
        public async Task GetProperty_ShouldReturnOk_WhenPropertyExists()
        {
            var property = new Property("Luxury Apartment", "LA", 800000, "Available", "Great view");
            _mockService.Setup(service => service.GetPropertyByIdAsync(1)).ReturnsAsync(property);

            var result = await _controller.GetProperty(1);

            result.Should().BeOfType<OkObjectResult>()
                  .Which.Value.Should().Be(property);
        }
        [Fact]
        public async Task GetProperty_ShouldReturnNotFound_WhenPropertyDoesNotExist()
        {
            _mockService.Setup(service => service.GetPropertyByIdAsync(99)).ReturnsAsync((Property)null);

            var result = await _controller.GetProperty(99);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateProperty_ShouldReturnCreatedAtAction()
        {
            var property = new Property("Modern Loft", "NYC", 450000, "Available", "Great investment");

            var result = await _controller.CreateProperty(property);

            result.Should().BeOfType<CreatedAtActionResult>();
            _mockService.Verify(service => service.CreatePropertyAsync(property), Times.Once);
        }

        [Fact]
        public async Task UpdateProperty_ShouldReturnNoContent_WhenUpdateIsSuccessful()
        {
            var property = new Property("Old House", "Boston", 200000, "Available", "Needs repair");
            _mockService.Setup(service => service.GetPropertyByIdAsync(1)).ReturnsAsync(property);

            var updatedProperty = new Property("Renovated House", "Boston", 250000, "Available", "Newly renovated");

            var result = await _controller.UpdateProperty(1, updatedProperty);

            result.Should().BeOfType<NoContentResult>();
            _mockService.Verify(service => service.UpdatePropertyAsync(It.Is<Property>(p =>
                p.Name == updatedProperty.Name &&
                p.Location == updatedProperty.Location &&
                p.Price == updatedProperty.Price &&
                p.Status == updatedProperty.Status &&
                p.Description == updatedProperty.Description
            )), Times.Once);
        }

        [Fact]
        public async Task DeleteProperty_ShouldReturnNoContent_WhenPropertyExists()
        {
            var property = new Property("Test House", "City", 500000, "Available", "Description");
            _mockService.Setup(service => service.GetPropertyByIdAsync(1)).ReturnsAsync(property);

            var result = await _controller.DeleteProperty(1);

            result.Should().BeOfType<NoContentResult>();
            _mockService.Verify(service => service.DeletePropertyAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteProperty_ShouldReturnNotFound_WhenPropertyDoesNotExist()
        {
            _mockService.Setup(service => service.GetPropertyByIdAsync(99)).ReturnsAsync((Property)null);

            var result = await _controller.DeleteProperty(99);

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
