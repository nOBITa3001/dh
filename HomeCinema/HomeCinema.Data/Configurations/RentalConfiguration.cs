namespace HomeCinema.Data.Configurations
{
	using HomeCinema.Entities;

	public class RentalConfiguration : EntityBaseConfiguration<Rental>
	{
		public RentalConfiguration()
		{
			Property(r => r.CustomerID).IsRequired();
			Property(r => r.StockID).IsRequired();
			Property(r => r.Status).IsRequired().HasMaxLength(10);
			Property(r => r.ReturnedDate).IsOptional();
		}
	}
}
