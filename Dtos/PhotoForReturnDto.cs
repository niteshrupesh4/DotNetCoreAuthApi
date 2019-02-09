using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public bool? IsMain { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public string PublicId { get; set; }
    }
}
