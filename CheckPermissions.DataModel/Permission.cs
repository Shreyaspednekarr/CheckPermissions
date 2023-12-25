using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("Permission", Schema = "dbo")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public int ApplicationId { get; set; }
        public string? Description { get; set; }

        //Navigation property to represent the UserPermission relationship
        public Application Application { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
