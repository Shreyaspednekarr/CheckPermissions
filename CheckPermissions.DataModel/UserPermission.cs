using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("UserPermissions", Schema = "dbo")]
    public class UserPermission
    {
        //Foreign keys
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        //Navigation properties
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
