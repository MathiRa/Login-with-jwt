﻿using System.ComponentModel.DataAnnotations;

namespace ALUXION.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s])^.{8,}$", ErrorMessage = "Password must have more than 8 characters which contain at least one numeric digit, one uppercase, one lowercase letter and one special character")]
        public string Password { get; set; }
    }
}
