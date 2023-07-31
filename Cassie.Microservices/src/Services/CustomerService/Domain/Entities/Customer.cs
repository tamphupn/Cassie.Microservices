using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cassie.Contracts.Domains;

namespace CustomerService.Domain.Entities
{
	public class Customer: EntityBase<int>
	{
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; } = default!;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string LastName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = default!;
    }
}