using System.ComponentModel.DataAnnotations;

namespace ContactManager.Model
{
    public class ContactModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O contato deve ter exatamente 9 dígitos.")]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string? Email { get; set; }
    }
}
