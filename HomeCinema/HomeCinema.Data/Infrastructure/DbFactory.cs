namespace HomeCinema.Data.Infrastructure
{
	public class DbFactory : Disposable, IDbFactory
	{
		HomeCinemaContext dbContext;

		public HomeCinemaContext Init()
		{
			return (this.dbContext ?? (this.dbContext = new HomeCinemaContext()));
		}

		protected override void DisposeCore()
		{
			if (this.dbContext != null)
			{
				this.dbContext.Dispose();
			}
		}
	}
}
