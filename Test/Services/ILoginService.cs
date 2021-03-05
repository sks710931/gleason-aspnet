using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Controllers;

namespace Test.Services
{
    public interface ILoginService
    {
        User Login(LoginRequest requestUser);
        List<User> GetAllUsers();
    }
}
