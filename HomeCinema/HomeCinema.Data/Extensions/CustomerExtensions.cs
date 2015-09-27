namespace HomeCinema.Data.Extensions
{
	using Entities;
	using Repositories;
	using System;
	using System.Linq;

	public static class CustomerExtensions
	{
		public static bool UserExists(this IEntityBaseRepository<Customer> customersRepository, string email, string identityCard)
		{
			return customersRepository.GetAll().Any(c => c.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)
															|| c.IdentityCard.Equals(identityCard, StringComparison.InvariantCultureIgnoreCase));
		}

		public static string GetCustomerFullName(this IEntityBaseRepository<Customer> customersRepository, int customerId)
		{
			var result = string.Empty;

			var customer = customersRepository.GetSingle(customerId);
			if (customer != null)
			{
				result = string.Format("{0} {1}", customer.FirstName, customer.LastName);
			}

			return result;
		}
	}
}
