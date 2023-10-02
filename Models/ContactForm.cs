using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactForm
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(5, ErrorMessage = "Message must be at least 5 characters long.")]
        public string Message { get; set; } = null!;
        public string? RedirectUrl { get; set; } = "/";
    }
}
