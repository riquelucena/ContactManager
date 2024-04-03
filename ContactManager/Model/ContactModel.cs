using System.ComponentModel.DataAnnotations;

namespace ContactManager.Model
{
    public class ContactModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "The Name must be at least 6 characters long.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Contact field is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "The Contact must be 9 digits long.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email must be a valid email address.")]
        public string? Email { get; set; }
    }
}
