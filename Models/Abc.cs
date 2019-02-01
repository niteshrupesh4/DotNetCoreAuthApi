using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Abc
    {
        public Abc()
        {
            InverseEmpSv = new HashSet<Abc>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? EmpSvid { get; set; }

        public virtual Abc EmpSv { get; set; }
        public virtual ICollection<Abc> InverseEmpSv { get; set; }
    }
}
