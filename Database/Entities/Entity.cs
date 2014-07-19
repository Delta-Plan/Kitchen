using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = -1;
        }

        public int Id { get; set; }

        public bool IsNew()
        {
            return Id == -1;
        }
    }
}
