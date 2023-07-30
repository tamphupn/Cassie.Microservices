using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cassie.Contracts.Domains;

namespace ProductService.Domain.Entities
{
	public class CatalogProduct: EntityBase<long>
	{
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string No { get; set; } = default!;

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = default!;

        [Column(TypeName = "nvarchar(255)")]
        public string Summary { get; set; } = default!;

        [Column(TypeName = "text")]
        public string Description { get; set; } = default!;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}