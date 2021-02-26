using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}