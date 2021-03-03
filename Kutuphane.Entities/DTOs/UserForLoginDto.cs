using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}