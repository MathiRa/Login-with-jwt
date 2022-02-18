using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ALUXION.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string Email { get; set; }

        public ProviderType Provider { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }
        public Role? Role { get; set; }
        public int? RoleId { get; set; }

    }
}
