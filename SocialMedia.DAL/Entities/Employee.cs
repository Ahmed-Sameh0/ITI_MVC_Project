using System.ComponentModel.DataAnnotations;

namespace SocialMedia.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }

        [Range(22, 60, ErrorMessage = "Age must be between 22 and 60.")]
        public int Age { get; set; }

        public decimal? Salary { get; set; }

        public string? ImagePath { get; set; }
    }
}
