namespace HomeCinema.Web.Infrastructure.Validators
{
	using FluentValidation;
	using Models;
	using System;

	public class MovieViewModelValidator : AbstractValidator<MovieViewModel>
	{
		public MovieViewModelValidator()
		{
			this.RuleFor(movie => movie.GenreId).GreaterThan(0)
				.WithMessage("Select a Genre");

			this.RuleFor(movie => movie.Director).NotEmpty().Length(1,100)
				.WithMessage("Select a Director");

			this.RuleFor(movie => movie.Writer).NotEmpty().Length(1,50)
				.WithMessage("Select a writer");

			this.RuleFor(movie => movie.Producer).NotEmpty().Length(1, 50)
				.WithMessage("Select a producer");

			this.RuleFor(movie => movie.Description).NotEmpty()
				.WithMessage("Select a description");

			this.RuleFor(movie => movie.Rating).InclusiveBetween((byte)0, (byte)5)
				.WithMessage("Rating must be less than or equal to 5");

			this.RuleFor(movie => movie.TrailerURI).NotEmpty().Must(ValidTrailerURI)
				.WithMessage("Only Youtube Trailers are supported");
		}

		private bool ValidTrailerURI(string trailerURI)
		{
			return (!string.IsNullOrWhiteSpace(trailerURI)
					&& trailerURI.StartsWith("https://www.youtube.com/watch?", StringComparison.InvariantCultureIgnoreCase));
		}
	}
}