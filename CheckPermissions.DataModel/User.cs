using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }

        //Navigation property to represent the UserRole relationship
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
