using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class NewsletterForm
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? RedirectUrl { get; set; } = "/";
    }
}
