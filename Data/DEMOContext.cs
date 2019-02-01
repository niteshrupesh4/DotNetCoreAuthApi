using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingApp.API.Models
{
    public partial class DEMOContext : DbContext
    {
        public DEMOContext()
        {
        }

        public DEMOContext(DbContextOptions<DEMOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abc> Abc { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Tbl1> Tbl1 { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }

        // Unable to generate entity type for table 'dbo.T1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.T2'. Please see the warning messages.

    }
}
