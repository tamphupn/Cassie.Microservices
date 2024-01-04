using System;
using Cassie.Contracts.Domains;

namespace OrderService.Domain.Entities
{
	public class Order: EntityAuditBase<long>
	{
		public string UserName { get; set; }
		public decimal TotalPrice { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
	}
}

