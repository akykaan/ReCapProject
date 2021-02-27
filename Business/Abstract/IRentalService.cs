using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IResult Add(Rental rentals);
		IResult Update(Rental rentals);
		IResult Delete(Rental rentals);
		//IResult CheckReturnDate(int carId);
		IDataResult<List<Rental>> GetAll();
	}
}
