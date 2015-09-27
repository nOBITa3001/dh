namespace HomeCinema.Data.Extensions
{
	using Entities;
	using Repositories;
	using System.Collections.Generic;
	using System.Linq;

	public static class StockExtensions
	{
		public static IEnumerable<Stock> GetAvailableItems(this IEntityBaseRepository<Stock> stocksRepository, int movieId)
		{
			return stocksRepository.GetAll().Where(s => s.MovieID == movieId && s.IsAvailable);
		}

		//public static IEnumerable<Stock> GetAllItems(this IEntityBaseRepository<Stock> stocksRepository, int movieId)
		//{
		//    IEnumerable<Stock> _allItems;

		//    _allItems = stocksRepository.GetAll().Where(s => s.MovieId == movieId);

		//    return _allItems;
		//}
	}
}
