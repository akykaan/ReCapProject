using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());

			brandManager.Add(new Brand { Id = 4, Name = "Porsche" });
			colorManager.Add(new Color { Id = 4, Name = "Sarı" });

			Console.WriteLine("\n-----Add-----\n");
			CarAdd(carManager);

			Console.WriteLine("\n-----CarGetById-----\n");
			CarGetById(carManager);

			Console.WriteLine("\n-----CarGetAll-----\n");
			CarGetAll(carManager);

			Console.WriteLine("\n-----CarTest-----\n");
			CarTest();

			Console.WriteLine("\n-----CarDelete-----\n");
			CarDelete(carManager);

			Console.WriteLine("\n-----CarTest-----\n");
			CarTest();

		}

		private static void CarDelete(CarManager carManager)
		{
			carManager.Delete(
				new Car
				{
					Id = 4,
					Name = "Porsche",
					BrandId = 4,
					ColorId = 2,
					ModelYear = 2005,
					DailyPrice = 300,
					Description = "Kiralık"
				});
		}

		private static void CarAdd(CarManager carManager)
		{
			carManager.Add(
				new Car
				{
					Id = 4,
					Name = "Porsche",
					BrandId = 4,
					ColorId = 2,
					ModelYear = 2005,
					DailyPrice = 300,
					Description = "Kiralık"
				});
		}

		

		private static void CarGetById(CarManager carManager)
		{
			foreach (var car in carManager.GetById(3))
			{
				Console.WriteLine(
					"Car Id:" + car.Id +
					"Name:" + car.Name +
					"Brand Id:" + car.BrandId +
					"Color Id:" + car.ColorId +
					"Model Year:" + car.ModelYear +
					"Daily Price:" + car.DailyPrice +
					"Description:" + car.Description);
			}
		}

		private static void CarGetAll(CarManager carManager)
		{
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(
					"Car Id:" + car.Id +
					"Name:" + car.Name +
					"Brand Id:" + car.BrandId +
					"Color Id:" + car.ColorId +
					"Model Year:" + car.ModelYear +
					"Daily Price:" + car.DailyPrice +
					"Description:" + car.Description);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			foreach (var car in carManager.GetCarDetails())
			{
				Console.WriteLine(
					"Car Name:" + car.CarName +"\n"+
					"Brand Name:" + car.BrandName + "\n" +
					"Color Name:" + car.ColorName + "\n " +
					"Daily Price:" + car.DailyPrice);
			}
		}
	}
}
