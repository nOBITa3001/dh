﻿namespace HomeCinema.Entities
{
	using System.Collections.Generic;

	public class Genre : IEntityBase
	{
		public Genre()
		{
			this.Movies = new List<Movie>();
		}

		public int ID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Movie> Movies { get; set; }
	}
}
