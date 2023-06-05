using CMS.DATA.Enum;
using System.ComponentModel.DataAnnotations;

namespace CMS.DATA.Entities
{
    public class Lesson : BaseEntity
    {
        public string CourseId { get; set; }
        public string AddedById { get; set; }
        public Modules Module { get; set; }
        public ModuleWeeks Weeks { get; set; }

        [MaxLength(150)]
        public string Topic { get; set; }

        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string PublicId { get; set; }
        public bool CompletionStatus { get; set; }
        public Course Course { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public ICollection<Quiz> Quizes { get; set; }
    }
}
