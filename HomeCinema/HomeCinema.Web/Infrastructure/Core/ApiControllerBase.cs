namespace HomeCinema.Web.Infrastructure.Core
{
	using Data.Infrastructure;
	using Data.Repositories;
	using Entities;
	using System;
	using System.Data.Entity.Infrastructure;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	public class ApiControllerBase : ApiController
	{
		protected readonly IEntityBaseRepository<Error> errorsRepository;
		protected readonly IUnitOfWork unitOfWork;

		public ApiControllerBase(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
		{
			this.errorsRepository = errorsRepository;
			this.unitOfWork = unitOfWork;
		}

		//public ApiControllerBase(IDataRepositoryFactory dataRepositoryFactory, IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
		//{
		//    _errorsRepository = errorsRepository;
		//    _unitOfWork = unitOfWork;
		//}

		protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
		{
			var response = default(HttpResponseMessage);

			try
			{
				response = function.Invoke();
			}
			catch (DbUpdateException ex)
			{
				this.LogError(ex);
				response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
			}
			catch (Exception ex)
			{
				this.LogError(ex);
				response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return response;
		}
		private void LogError(Exception ex)
		{
			try
			{
				var error = new Error()
				{
					Message = ex.Message,
					StackTrace = ex.StackTrace,
					DateCreated = DateTime.Now
				};

				this.errorsRepository.Add(error);
				this.unitOfWork.Commit();
			}
			catch { }
		}
	}
}