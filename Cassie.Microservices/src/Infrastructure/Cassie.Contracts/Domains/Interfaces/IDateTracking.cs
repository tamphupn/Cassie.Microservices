namespace Cassie.Contracts.Domains.Interfaces
{
	public interface IDateTracking
	{
		public DateTimeOffset? CreatedDate { get; set; }
		public DateTimeOffset? LastModifiedDate { get; set; }
	}
}

