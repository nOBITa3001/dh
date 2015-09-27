namespace HomeCinema.Data.Configurations
{
	using Entities;

	public class GenreConfiguration : EntityBaseConfiguration<Genre>
	{
		public GenreConfiguration()
		{
			this.Property(g => g.Name).IsRequired().HasMaxLength(50);
		}
	}
}
