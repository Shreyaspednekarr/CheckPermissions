using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckPermissions.DataModel
{
    [Table("Application", Schema = "dbo")]
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string? Description { get; set; }
    }
}
