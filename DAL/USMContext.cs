using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using USM.DAL.Models;

namespace USM.DAL
{
    public class USMContext: DbContext
    {
        public USMContext() : base("USMContext")
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
