using System;

namespace Ordering.Domain.Common
{
    /// <summary>
    /// Every class will have these properties
    /// </summary>    
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
