using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SquadNumber { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
