using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ResourceUpdateViewModel
    {
        public int ResourceId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
    }
}
