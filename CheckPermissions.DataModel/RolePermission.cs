using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("RolePermissions", Schema = "dbo")]
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        //Navigation properties
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
