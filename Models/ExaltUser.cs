using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class ExaltUser
    {
        public ExaltUser()
        {
            Photos = new HashSet<Photo>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string KnownAs { get; set; }
        public string Created { get; set; }
        public string LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
