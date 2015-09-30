namespace HomeCinema.Web.Controllers
{
	using AutoMapper;
	using Data.Infrastructure;
	using Data.Repositories;
	using Entities;
	using Infrastructure.Core;
	using Models;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	[Authorize(Roles = "Admin")]
	[RoutePrefix("api/genres")]
	public class GenresController : ApiControllerBase
	{
		private readonly IEntityBaseRepository<Genre> genresRepository;

		public GenresController(IEntityBaseRepository<Genre> genresRepository
								, IEntityBaseRepository<Error> errorsRepository
								, IUnitOfWork unitOfWork)
			: base(errorsRepository, unitOfWork)
		{
			this.genresRepository = genresRepository;
		}

		[AllowAnonymous]
		public HttpResponseMessage Get(HttpRequestMessage request)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var genres = this.genresRepository.GetAll().ToList();
					var genresVM = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);

					return request.CreateResponse(HttpStatusCode.OK, genresVM);
				});
		}
	}
}
