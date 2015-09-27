namespace HomeCinema.Services.Utilities
{
	using Entities;
	using System.Security.Principal;

	public class MembershipContext
	{
		public IPrincipal Principal { get; set; }
		public User User { get; set; }
		public bool IsValid()
		{
			return Principal != null;
		}
	}
}
