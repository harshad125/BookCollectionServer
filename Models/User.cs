using MyCollection.Models;
using AutoMapper;
namespace MyCollection.Models
{
    public class User
    {
        public long id { get; set; }

        public string User_Name { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; } = Array.Empty<byte>();

        public byte[]? PasswordSalt { get; set; } = Array.Empty<byte>();

        public string Email { get; set; }

     //   public string Password { get; set; }

        public string Mobile { get; set; }

    }

   /* public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
   */
    public class UserDto
    {
        public long id { get; set; }

        public string User_Name { get; set; } = string.Empty;

        public string Email { get; set; }

       // public string Password { get; set; }

        public string Mobile { get; set; }
        public List<Book> Books { get; set; }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
