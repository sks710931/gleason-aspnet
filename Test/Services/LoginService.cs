using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Controllers;

namespace Test.Services
{
    public class LoginService: ILoginService
    {
        private List<User> users;
        public LoginService()
        {
            users = new List<User>
            {
                new User() { Email = "user@email.com", Password = "pass123$", Name = "Test User", Username = "test" }
            };

        }

        public List<User> GetAllUsers()
        {
            users.Add(new User() { Email = "user2@email.com", Password = "pass123$", Name = "Test User2", Username = "test2" });
            users.Add(new User() { Email = "user3@email.com", Password = "pass123$", Name = "Test User3", Username = "test3" });
            return users;
        }

        public User Login(LoginRequest loginuser)
        {
            var user = users.Find(x => x.Username == loginuser.Username);
            if (user != null)
            {
                if (user.Username == loginuser.Username)
                    return user;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
