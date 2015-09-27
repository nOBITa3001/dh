namespace HomeCinema.Data.Configurations
{
	using Entities;
	using System.Data.Entity.ModelConfiguration;

	public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
	{
		public EntityBaseConfiguration()
		{
			this.HasKey(e => e.ID);
		}
	}
}
