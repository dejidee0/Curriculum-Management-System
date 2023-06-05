using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.DATA.Entities
{
    public class UserCourse : BaseEntity
    {
        [ForeignKey("Course")]
        public string CourseId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public Course Course { get; set; }
        public ApplicationUser User {get; set; }

        public bool CompletionStatus { get; set; }
    }
}
