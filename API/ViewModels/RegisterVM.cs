using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        public int RoleId { get; set; } 

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;
    }
}