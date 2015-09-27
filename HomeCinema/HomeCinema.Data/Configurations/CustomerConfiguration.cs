namespace HomeCinema.Data.Configurations
{
	using Entities;

	public class CustomerConfiguration : EntityBaseConfiguration<Customer>
	{
		public CustomerConfiguration()
		{
			this.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
			this.Property(u => u.LastName).IsRequired().HasMaxLength(100);
			this.Property(u => u.IdentityCard).IsRequired().HasMaxLength(50);
			this.Property(u => u.UniqueKey).IsRequired();
			this.Property(c => c.Mobile).HasMaxLength(10);
			this.Property(c => c.Email).IsRequired().HasMaxLength(200);
			this.Property(c => c.DateOfBirth).IsRequired();
		}
	}
}
