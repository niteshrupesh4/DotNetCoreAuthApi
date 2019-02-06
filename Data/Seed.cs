using DatingApp.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DEMOContext _context;
        public Seed(DEMOContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("D:/Nitesh Share/DotNetCore/DatingApp.API/Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<ExaltUser>>(userData);
            foreach (var item in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("test", out passwordHash, out passwordSalt);
                item.PasswordHash = passwordHash;
                item.PasswordSalt = passwordSalt;
                item.Username = item.Username.ToLower();

                _context.ExaltUser.Add(item);
            }

            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
