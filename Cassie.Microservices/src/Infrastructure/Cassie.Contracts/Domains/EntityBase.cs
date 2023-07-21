using Cassie.Contracts.Domains.Interfaces;

namespace Cassie.Contracts.Domains
{
	public abstract class EntityBase<T>: IEntityBase<T>
	{

        public T Id { get; set; }
    }
}