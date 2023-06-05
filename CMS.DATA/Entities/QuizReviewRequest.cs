using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.Entities
{
    public class QuizReviewRequest: BaseEntity
    {
       
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }
    }
}
