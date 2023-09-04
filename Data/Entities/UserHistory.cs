using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserHistory
    {
        public int history_id { get; set; }
        public int UserId { get; set; }       
        public string Action { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
