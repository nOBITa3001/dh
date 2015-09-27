namespace HomeCinema.Data.Configurations
{
	using Entities;

	public class UserRoleConfiguration : EntityBaseConfiguration<UserRole>
	{
		public UserRoleConfiguration()
		{
			this.Property(ur => ur.UserID).IsRequired();
			this.Property(ur => ur.RoleID).IsRequired();
		}
	}
}
