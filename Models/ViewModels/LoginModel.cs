using Microsoft.AspNetCore.Mvc;
using GundamEvolutionDatabase.Models;
using System.ComponentModel.DataAnnotations;

namespace GundamEvolutionDatabase.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        public string? UName { get; set; }

        [Required(ErrorMessage = "Please enter the password.")]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; } = "/";
    }
}
