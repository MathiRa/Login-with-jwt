using System.ComponentModel.DataAnnotations;

namespace ALUXION.DTOs
{
    public class ValidUserDto
    {
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
    }
}
