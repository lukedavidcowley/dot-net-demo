using System;

namespace LukeCowley.Data.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public EntityBase()
        {
            UpdatedOn = DateTime.Now;
        }
    }
}
