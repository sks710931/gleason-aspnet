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
                new User() { Email = "user@email.com", Password = "pass123$", Name = "Test User", Username = "test", Id = 1},
                new User() { Id = 2, Email = "user2@email.com", Password = "pass123$", Name = "Test User2", Username = "test2" },
            new User() { Id = 3, Email = "user3@email.com", Password = "pass123$", Name = "Test User3", Username = "test3" }
        };

        }

        public User AddUser(User user)
        {
            user.Id = users[users.Count - 1].Id + 1;
            users.Add(user);
            return user;
        }

        public bool DeleteUser(int id)
        {
            var userToremove = users.Find(x => x.Id == id);
            try
            {
                users.Remove(userToremove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            
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
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
