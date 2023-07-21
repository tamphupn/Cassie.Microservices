using Cassie.Contracts.Domains.Interfaces;

namespace Cassie.Contracts.Domains
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IAuditable, IDateTracking
    {
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}