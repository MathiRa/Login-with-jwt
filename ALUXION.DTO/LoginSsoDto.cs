using System.ComponentModel.DataAnnotations;

namespace ALUXION.DTOs
{
    public class LoginSsoDto
    {
        public string IdToken { get; set; }
        public ProviderTypeDto Provider { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
