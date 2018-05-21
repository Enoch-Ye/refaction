using refactor_me.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Persistence
{
    /// <summary>
    /// RefactorMeContext
    /// </summary>
    public class RefactorMeContext : DbContext
    {
        public RefactorMeContext() : base("DefaultConnection")
        {
            //no-op
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOption>().HasRequired(p => p.Product).WithMany(d => d.ProductOptions).HasForeignKey<Guid>(s => s.ProductId).WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
