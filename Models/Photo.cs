using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public int? UserId { get; set; }
        public virtual ExaltUser User { get; set; }
    }
}
