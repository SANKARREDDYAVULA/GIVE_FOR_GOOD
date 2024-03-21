using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiveForGood.Web.Service.Models
{
    [Table("Role")]
    public class Role : Common
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
