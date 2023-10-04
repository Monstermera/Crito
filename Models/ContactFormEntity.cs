using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class ContactFormEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Please enter a valid first name")]
        public string Name { get; set; } = null!;


        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = null!;

    }
}
