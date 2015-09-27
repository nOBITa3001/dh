namespace HomeCinema.Entities
{
	using System;

	public class Rental : IEntityBase
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public int StockID { get; set; }
		public virtual Stock Stock { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime? ReturnedDate { get; set; }
		public string Status { get; set; }
	}
}