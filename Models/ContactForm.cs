using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;


        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = null!;

        public string? RedirectUrl { get; set; } = "/";

    }
}
