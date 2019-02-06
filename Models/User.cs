﻿using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
