using System.ComponentModel.DataAnnotations;

namespace YCHW.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Available, Rented, Sold

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Property() { }
        public Property(string name, string location, decimal price, string status, string description)
        {
            Name = name;
            Location = location;
            Price = price;
            Status = status;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
