using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DATA.Entities
{
    public class UserStack : BaseEntity
    {
        [ForeignKey("Stack")]
        public string StackId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public virtual Stack Stack { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}