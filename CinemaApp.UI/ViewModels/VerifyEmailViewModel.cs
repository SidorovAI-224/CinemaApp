using System.ComponentModel.DataAnnotations;

namespace CinemaApp.UI.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
