using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.DTO
{
    public class GetAllUsersDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SquadNumber { get; set; }
        public string? PublicId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
