using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}