namespace HomeCinema.Entities
{
	using System;
	using System.Collections.Generic;

	public class Stock : IEntityBase
	{
		public Stock()
		{
			this.Rentals = new List<Rental>();
		}

		public int ID { get; set; }
		public int MovieID { get; set; }
		public virtual Movie Movie { get; set; }
		public Guid UniqueKey { get; set; }
		public bool IsAvailable { get; set; }
		public virtual ICollection<Rental> Rentals { get; set; }
	}
}