using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

    }
}
