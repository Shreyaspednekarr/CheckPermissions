using CheckPermissions.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.Repository
{
    public class CheckPermissionsDbModel(DbContextOptions<CheckPermissionsDbModel> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UserRoles
            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            //UserPermissions
            modelBuilder.Entity<UserPermission>()
                .HasKey(x => new { x.UserId, x.PermissionId });

            modelBuilder.Entity<UserPermission>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.PermissionId);

            //RolePermissions
            modelBuilder.Entity<RolePermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.PermissionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
