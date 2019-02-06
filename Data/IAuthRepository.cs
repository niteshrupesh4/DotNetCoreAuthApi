using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<ExaltUser> Register(ExaltUser user, string password);
        Task<ExaltUser> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
