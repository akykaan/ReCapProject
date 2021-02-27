using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator:AbstractValidator<Car>
	{
		//kurallar buraya yazılacak
		public CarValidator()
		{
			RuleFor(c => c.DailyPrice).GreaterThan(0)
				.WithMessage("günlük fiyatı 0'dan büyük giriniz!");
		}
	}
}
