using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<Tbl_User> Register(Tbl_User user, string password);
        Task<Tbl_User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
