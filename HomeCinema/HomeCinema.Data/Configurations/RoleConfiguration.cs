namespace HomeCinema.Data.Configurations
{
	using Entities;

	public class RoleConfiguration : EntityBaseConfiguration<Role>
	{
		public RoleConfiguration()
		{
			this.Property(ur => ur.Name).IsRequired().HasMaxLength(50);
		}
	}
}
