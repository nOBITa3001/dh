namespace HomeCinema.Data.Repositories
{
	using Entities;
	using Infrastructure;
	using System;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;

	public class EntityBaseRepository<T> : IEntityBaseRepository<T>
			where T : class, IEntityBase, new()
	{

		private HomeCinemaContext dataContext;

		#region Properties

		protected IDbFactory DbFactory { get; private set; }

		protected HomeCinemaContext DbContext
		{
			get { return this.dataContext ?? (this.dataContext = this.DbFactory.Init()); }
		}
		public EntityBaseRepository(IDbFactory dbFactory)
		{
			this.DbFactory = dbFactory;
		}

		#endregion

		public virtual IQueryable<T> GetAll()
		{
			return this.DbContext.Set<T>();
		}

		public virtual IQueryable<T> All
		{
			get
			{
				return this.GetAll();
			}
		}

		public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = DbContext.Set<T>();
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public T GetSingle(int id)
		{
			return this.GetAll().SingleOrDefault(x => x.ID == id);
		}

		public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			return this.DbContext.Set<T>().Where(predicate);
		}

		public virtual void Add(T entity)
		{
			var dbEntityEntry = this.DbContext.Entry<T>(entity);
			this.DbContext.Set<T>().Add(entity);
		}

		public virtual void Edit(T entity)
		{
			var dbEntityEntry = this.DbContext.Entry<T>(entity);
			dbEntityEntry.State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			var dbEntityEntry = this.DbContext.Entry<T>(entity);
			dbEntityEntry.State = EntityState.Deleted;
		}
	}
}
