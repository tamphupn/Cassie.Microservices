namespace Cassie.Contracts.Domains.Interfaces
{
	public interface IEntityBase<T>
	{
		public T Id { get; set; }
	}
}