using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator:AbstractValidator<Car>
	{
		//kurallar buraya yazılacak
		public CarValidator()
		{
			RuleFor(c => c.DailyPrice).GreaterThan(0)
				.WithMessage("günlük fiyatı 0'dan büyük giriniz!");
			//RuleFor(c => c.Description).Must(StartWithCapitalLetter).WithMessage("Description ilk harf büyük olmalıdır.");
		}

		private bool StartWithCapitalLetter(string arg)
		{
			string copyToArg = arg.ToUpper();

			return arg[0].ToString() == copyToArg[0].ToString() ? true : false;

		}
	}
}
