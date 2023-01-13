using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourMovies.Domain.Entities
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set;}

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
