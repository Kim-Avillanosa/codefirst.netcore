using System;
using System.Collections.Generic;
using System.Text;

namespace codefirst.netcore.infrastructure.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
