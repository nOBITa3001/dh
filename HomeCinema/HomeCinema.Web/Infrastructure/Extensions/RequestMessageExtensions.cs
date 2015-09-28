namespace HomeCinema.Web.Infrastructure.Extensions
{
	using Data.Repositories;
	using Entities;
	using Services;
	using System.Net.Http;

	public static class RequestMessageExtensions
	{
		internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
		{
			return request.GetService<IMembershipService>();
		}

		internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request)
			where T : class, IEntityBase, new()
		{
			return request.GetService<IEntityBaseRepository<T>>();
		}

		private static TService GetService<TService>(this HttpRequestMessage request)
		{
			var dependencyScope = request.GetDependencyScope();
			return (TService)dependencyScope.GetService(typeof(TService));
		}
	}
}