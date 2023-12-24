using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.DataModel.Requests
{
    public class CreateApplicationRequest
    {
        [Required]
        public string ApplicationName { get; set; }
        public string Description { get; set; }
    }
}
