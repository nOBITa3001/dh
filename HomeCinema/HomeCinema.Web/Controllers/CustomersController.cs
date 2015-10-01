namespace HomeCinema.Web.Controllers
{
	using AutoMapper;
	using Data.Extensions;
	using Data.Infrastructure;
	using Data.Repositories;
	using Entities;
	using Infrastructure.Core;
	using Infrastructure.Extensions;
	using Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	[Authorize(Roles="Admin")]
	[RoutePrefix("api/customers")]
	public class CustomersController : ApiControllerBase
	{
		private readonly IEntityBaseRepository<Customer> customersRepository;

		public CustomersController(IEntityBaseRepository<Customer> customersRepository
									, IEntityBaseRepository<Error> errorsRepository
									, IUnitOfWork unitOfWork)
			: base(errorsRepository, unitOfWork)
		{
			this.customersRepository = customersRepository;
		}

		//public HttpResponseMessage Get(HttpRequestMessage request, string filter)
		//{
		//	filter = filter.ToLower().Trim();

		//	return CreateHttpResponse(request, () =>
		//	{
		//		HttpResponseMessage response = null;

		//		var customers = customersRepository.GetAll()
		//			.Where(c => c.Email.ToLower().Contains(filter) ||
		//			c.FirstName.ToLower().Contains(filter) ||
		//			c.LastName.ToLower().Contains(filter)).ToList();

		//		var customersVm = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

		//		response = request.CreateResponse<IEnumerable<CustomerViewModel>>(HttpStatusCode.OK, customersVm);

		//		return response;
		//	});
		//}

		//[Route("details/{id:int}")]
		//public HttpResponseMessage Get(HttpRequestMessage request, int id)
		//{
		//	return CreateHttpResponse(request, () =>
		//	{
		//		HttpResponseMessage response = null;
		//		var customer = customersRepository.GetSingle(id);

		//		CustomerViewModel customerVm = Mapper.Map<Customer, CustomerViewModel>(customer);

		//		response = request.CreateResponse<CustomerViewModel>(HttpStatusCode.OK, customerVm);

		//		return response;
		//	});
		//}

		[HttpPost]
		[Route("register")]
		public HttpResponseMessage Register(HttpRequestMessage request, CustomerViewModel customer)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var response = default(HttpResponseMessage);

					if (!ModelState.IsValid)
					{
						response = request.CreateResponse(HttpStatusCode.BadRequest
															, ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray());
					}
					else
					{
						if (this.customersRepository.UserExists(customer.Email, customer.IdentityCard))
						{
							ModelState.AddModelError("Invalid user", "Email or Identity Card number already exists");
							response = request.CreateResponse(HttpStatusCode.BadRequest
																, ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray());
						}
						else
						{
							var newCustomer = new Customer();
							newCustomer.UpdateCustomer(customer);
							customersRepository.Add(newCustomer);

							this.unitOfWork.Commit();

							// Update view model
							customer = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
							response = request.CreateResponse<CustomerViewModel>(HttpStatusCode.Created, customer);
						}
					}

					return response;
				});
		}

		[HttpPost]
		[Route("update")]
		public HttpResponseMessage Update(HttpRequestMessage request, CustomerViewModel customer)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var response = default(HttpResponseMessage);

					if (!ModelState.IsValid)
					{
						response = request.CreateResponse(HttpStatusCode.BadRequest
															, ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray());
					}
					else
					{
						var _customer = this.customersRepository.GetSingle(customer.ID);
						_customer.UpdateCustomer(customer);

						this.unitOfWork.Commit();

						response = request.CreateResponse(HttpStatusCode.OK);
					}

					return response;
				});
		}

		[HttpGet]
		[Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
		public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
		{
			return CreateHttpResponse(
				request
				, () =>
				{
					var customers = default(IEnumerable<Customer>);

					if (!string.IsNullOrWhiteSpace(filter))
					{
						filter = filter.Trim().ToLower();

						customers = this.customersRepository.GetAll()
															.Where(c => c.LastName.ToLower().Contains(filter)
																|| c.IdentityCard.ToLower().Contains(filter)
																|| c.FirstName.ToLower().Contains(filter))
															.OrderBy(c => c.ID);
					}
					else
					{
						customers = this.customersRepository.GetAll();
					}

					var currentPage = page.Value;
					var currentPageSize = pageSize.Value;
					var totalMovies = customers.Count();

					customers = customers.Skip(currentPage * currentPageSize)
											.Take(currentPageSize);

					var customersVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

					var pagedSet = new PaginationSet<CustomerViewModel>()
					{
						Page = currentPage,
						TotalCount = totalMovies,
						TotalPages = (int)Math.Ceiling((decimal)totalMovies / currentPageSize),
						Items = customersVM
					};

					return request.CreateResponse(HttpStatusCode.OK, pagedSet);
				});
		}
	}
}
