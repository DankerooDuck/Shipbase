using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GundamEvolutionDatabase.Models.ViewModels
{
    public class CreateModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string? FName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string? LName { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        public string? UName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }

        public string? ReturnUrl { get; set; } = "/";
    }
}
