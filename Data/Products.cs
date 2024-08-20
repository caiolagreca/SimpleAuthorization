using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicAuthorization.Data
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdentityUser")]
        public string CreatedUserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
