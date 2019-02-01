using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public class ExaltPayDbContext:DbContext
    {
        public ExaltPayDbContext(DbContextOptions<ExaltPayDbContext> options)
            : base(options)
        {  }
        public virtual DbSet<Mct_PlanDetail> Mct_PlanDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mct_PlanDetail>()
                .HasKey(o => new { o.plan_id,o.merchant_id,o.product_id });
        }
    }
}
