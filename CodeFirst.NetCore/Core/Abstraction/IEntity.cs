using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore 
{
    public interface IEntity
    {
        public int Id { get; }
    }

    public interface ITimestampedEntity : IEntity
    {
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }


    public abstract class Entity : ITimestampedEntity
    {
        int _Id;
        DateTime _updatedAt;
        DateTime _createdAt;

        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public virtual DateTime CreatedAt
        {
            get
            {
                return _createdAt;
            }
            protected set
            {
                _createdAt = value;
            }
        }

        public virtual DateTime UpdatedAt
        {
            get
            {
                return _updatedAt;
            }
            protected set
            {
                _updatedAt = value;
            }
        }

    }
}
