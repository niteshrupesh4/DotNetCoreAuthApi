using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
