using CheckPermissions.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.Repository
{
    public class CheckPermissionsDbModel(DbContextOptions<CheckPermissionsDbModel> options) : DbContext(options)
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
