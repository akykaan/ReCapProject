using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	/*public class InMemoryCarDal:ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			//Oracle,sql server,postgresql,
			//_cars = new List<Car> {
			//	new Car{Id=1,BrandId=11,ColorId=111,ModelYear=1994,DailyPrice=1000,Description="Kiralik"},
			//	new Car{Id=2,BrandId=22,ColorId=222,ModelYear=1995,DailyPrice=2000,Description="Satılık"},
			//	new Car{Id=3,BrandId=33,ColorId=333,ModelYear=1996,DailyPrice=3000,Description="Kiralik"},
			//	new Car{Id=4,BrandId=44,ColorId=444,ModelYear=1997,DailyPrice=4000,Description="Kiralik"},
			//	new Car{Id=5,BrandId=55,ColorId=555,ModelYear=1998,DailyPrice=5000,Description="Kiralik"}
			//};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(carToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int id)
		{
			return _cars.Where(c => c.Id == id).ToList();
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
			carToUpdate.ModelYear = car.ModelYear;
		}
	}*/
}
