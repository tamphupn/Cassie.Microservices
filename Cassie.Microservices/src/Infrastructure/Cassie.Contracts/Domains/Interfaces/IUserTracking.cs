using System;
namespace Cassie.Contracts.Domains.Interfaces
{
	public interface IUserTracking
	{
		string CreatedBy { get; set; }
		string ModifiedBy { get; set; }
	}
}

