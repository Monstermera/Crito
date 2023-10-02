using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class SubscriberEntity
    {
        [Key]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; } = null!;


    }
}
