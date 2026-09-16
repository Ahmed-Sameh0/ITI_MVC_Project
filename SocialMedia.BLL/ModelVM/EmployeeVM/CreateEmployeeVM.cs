using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SocialMedia.BLL.ModelVM.EmployeeVM
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }

        [Range(22, 60, ErrorMessage = "Age must be between 22 and 60.")]
        public int Age { get; set; }

        public IFormFile? Image { get; set; }
    }
}
