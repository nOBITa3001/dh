namespace HomeCinema.Data.Configurations
{
	using Entities;

	public class StockConfiguration : EntityBaseConfiguration<Stock>
	{
		public StockConfiguration()
		{
			this.Property(s => s.MovieID).IsRequired();
			this.Property(s => s.UniqueKey).IsRequired();
			this.Property(s => s.IsAvailable).IsRequired();
			this.HasMany(s => s.Rentals).WithRequired(r => r.Stock).HasForeignKey(r => r.StockID);
		}
	}
}
