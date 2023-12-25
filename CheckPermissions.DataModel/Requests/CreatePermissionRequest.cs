using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.DataModel.Requests
{
    public class CreatePermissionRequest
    {
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}
