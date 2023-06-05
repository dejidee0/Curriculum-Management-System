using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DATA.DTO
{
    public class GetuserByIdDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SquadNumber { get; set; }
        public string? PublicId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
