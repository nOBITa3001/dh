namespace HomeCinema.Data.Configurations
{
	using Entities;
	public class UserConfiguration : EntityBaseConfiguration<User>
	{
		public UserConfiguration()
		{
			this.Property(u => u.Username).IsRequired().HasMaxLength(100);
			this.Property(u => u.Email).IsRequired().HasMaxLength(200);
			this.Property(u => u.HashedPassword).IsRequired().HasMaxLength(200);
			this.Property(u => u.Salt).IsRequired().HasMaxLength(200);
			this.Property(u => u.IsLocked).IsRequired();
			this.Property(u => u.DateCreated);
		}
	}
}
