using System;
using System.Collections.Generic;
using System.Text;

namespace codefirst.netcore.infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public string LastName { get; set; }
        public int UserGroupId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
