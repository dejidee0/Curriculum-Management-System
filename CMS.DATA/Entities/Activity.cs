using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.Entities
{
    public class Activity: BaseEntity
    {
            public string Description { get; set; }
            public string UserId { get; set; }
            public ApplicationUser User { get; set; }
            public ICollection<Course> Courses { get; set; }
    }
}
