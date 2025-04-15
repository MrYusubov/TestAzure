using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.UI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
