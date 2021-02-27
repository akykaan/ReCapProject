using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class RentalValidator : AbstractValidator<Rental>
	{
		public RentalValidator()
		{		
			RuleFor(r => r.CarId).GreaterThanOrEqualTo(r1 => r1.CarId);
			RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).When(r => r.ReturnDate.HasValue).WithMessage("Rent Date Return Date'den büyük olamaz");
			RuleFor(r => r.RentDate).NotEmpty();
			RuleFor(r => r.ReturnDate).NotEmpty();
		}
		
	}
}
