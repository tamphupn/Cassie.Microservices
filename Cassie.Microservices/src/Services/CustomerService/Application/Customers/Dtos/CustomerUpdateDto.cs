namespace CustomerService.Application.Customers.Dtos
{
	public class CustomerUpdateDto
	{
        public string UserName { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;
    }
}