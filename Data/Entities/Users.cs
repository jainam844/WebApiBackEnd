using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
