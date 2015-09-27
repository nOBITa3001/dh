namespace HomeCinema.Services
{
	using Entities;
	using Services.Utilities;
	using System.Collections.Generic;

	public interface IMembershipService
	{
		MembershipContext ValidateUser(string username, string password);
		User CreateUser(string username, string email, string password, int[] roles);
		User GetUser(int id);
		List<Role> GetUserRoles(string username);
		List<Role> GetUserRoles(User user);
	}
}
