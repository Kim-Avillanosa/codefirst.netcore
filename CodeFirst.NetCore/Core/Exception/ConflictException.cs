using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public enum ConflictCode
    {
        record_not_found,
        invalid_type
    }
    public class ConflictException : Exception
    {
        public ConflictCode Code { get; set; }

        public string Description { get; set; }
        public ConflictException(ConflictCode code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
