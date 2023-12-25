using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("UserRoles", Schema = "dbo")]
    public class UserRole
    {
        //Foreign keys
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
