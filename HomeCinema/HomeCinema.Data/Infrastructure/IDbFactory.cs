namespace HomeCinema.Data.Infrastructure
{
	using System;

	public interface IDbFactory : IDisposable
	{
		HomeCinemaContext Init();
	}
}
