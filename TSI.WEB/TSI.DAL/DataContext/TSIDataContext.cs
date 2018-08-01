using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TSI.DAL.Models;

namespace TSI.DAL.DataContext
{
    public class TSIDataContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin,
        IdentityUserRole, IdentityUserClaim>
    {
        public TSIDataContext()
            : base("Name=TSIDataContext")
        {
        }

        public DbSet<Instroductions> Instroductionses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }

        public static TSIDataContext Create()
        {
            return new TSIDataContext();
        }
    }
}
