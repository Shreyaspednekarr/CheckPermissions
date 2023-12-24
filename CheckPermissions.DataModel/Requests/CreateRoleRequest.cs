using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.DataModel.Requests
{
    public class CreateRoleRequest
    {
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
