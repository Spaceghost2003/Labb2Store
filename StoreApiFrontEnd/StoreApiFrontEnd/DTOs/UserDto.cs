using StoreApi.Models;

namespace StoreApiFrontEnd.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
