namespace HomeCinema.Web.Controllers
{
	using Data.Infrastructure;
	using Data.Repositories;
	using Entities;
	using Infrastructure.Core;
	using Models;
	using Services;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	[Authorize(Roles="Admin")]
	[RoutePrefix("api/Account")]
	public class AccountController : ApiControllerBase
	{
		private readonly IMembershipService membershipService;

		public AccountController(IMembershipService membershipService
									, IEntityBaseRepository<Error> errorsRepository
									, IUnitOfWork unitOfWork)
			: base(errorsRepository, unitOfWork)
		{
			this.membershipService = membershipService;
		}

		[AllowAnonymous]
		[Route("authenticate")]
		[HttpPost]
		public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var response = default(HttpResponseMessage);

					if (ModelState.IsValid)
					{
						var userContext = this.membershipService.ValidateUser(user.Username, user.Password);

						if (userContext.User != null)
						{
							response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
						}
						else
						{
							response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
						}
					}
					else
					{
						response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
					}

					return response;
				});
		}

		[AllowAnonymous]
		[Route("register")]
		[HttpPost]
		public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var response = default(HttpResponseMessage);

					if (!ModelState.IsValid)
					{
						response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
					}
					else
					{
						var newUser = membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

						if (newUser != null)
						{
							response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
						}
						else
						{
							response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
						}
					}

					return response;
				});
		}
	}
}
