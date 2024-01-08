using System.ComponentModel.DataAnnotations;

namespace BasketService.Domain.Entities
{
    public class BasketCheckout
    {
        [Required]
        public string UserName { get; set; } = default!;
        public decimal TotalPrice { get; set; } = default!;
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = default!;
        [Required]
        public string ShippingAddress { get; set; } = default!;

        private string _invoiceAddress = default!;

        public string? InvoiceAddress
        {
            get => _invoiceAddress;
            set => _invoiceAddress = value ?? ShippingAddress;
        }
    }
}

