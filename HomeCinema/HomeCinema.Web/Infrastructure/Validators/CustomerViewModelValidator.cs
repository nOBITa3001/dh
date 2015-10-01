namespace HomeCinema.Web.Infrastructure.Validators
{
	using FluentValidation;
	using Models;
	using System;

	public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
	{
		public CustomerViewModelValidator()
		{
			this.RuleFor(customer => customer.FirstName).NotEmpty()
				.Length(1, 100).WithMessage("First Name must be between 1 - 100 characters");

			this.RuleFor(customer => customer.LastName).NotEmpty()
				.Length(1, 100).WithMessage("Last Name must be between 1 - 100 characters");

			this.RuleFor(customer => customer.IdentityCard).NotEmpty()
				.Length(1, 100).WithMessage("Identity Card must be between 1 - 50 characters");

			this.RuleFor(customer => customer.DateOfBirth).NotNull()
				.LessThan(DateTime.Now.AddYears(-16))
				.WithMessage("Customer must be at least 16 years old.");

			this.RuleFor(customer => customer.Mobile).NotEmpty().Matches(@"^\d{10}$")
				.Length(10).WithMessage("Mobile phone must have 10 digits");

			this.RuleFor(customer => customer.Email).NotEmpty().EmailAddress()
				.WithMessage("Enter a valid Email address");

		}
	}
}