using Microsoft.AspNetCore.Identity;

namespace UserApi.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}