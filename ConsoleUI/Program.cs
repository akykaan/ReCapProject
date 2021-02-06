using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());

			Console.WriteLine("-----GetAll-----");
			foreach (var cars in carManager.GetAll())
			{
				Console.WriteLine(
					"Id:"+cars.Id+" "+
					"Yılı:"+cars.BrandId + " "+
					"Color Id:"+ cars.ColorId + " "+
					"Model Year:" + cars.ModelYear + " " +
					"Daily Price:" + cars.DailyPrice + " " +
					"Description:" + cars.Description);
			}

			Console.WriteLine("-----GetById-----");
			foreach (var cars in carManager.GetById(2))
			{
				Console.WriteLine(
					"Id:" + cars.Id + " " +
					"Yılı:" + cars.BrandId + " " +
					"Color Id:" + cars.ColorId + " " +
					"Model Year:" + cars.ModelYear + " " +
					"Daily Price:" + cars.DailyPrice + " " +
					"Description:" + cars.Description);
			}
			carManager.Add(
				new Car 
				{ 
					Id = 7,
					BrandId = 77,
					ColorId=777,
					ModelYear = 1992, 
					DailyPrice = 5123,
					Description = "Kiralık"
				});

			Console.WriteLine("\nAdd sonrası cagırma\n");

			foreach (var cars in carManager.GetAll())
			{
				Console.WriteLine(
					"Id:" + cars.Id + " " +
					"Yılı:" + cars.BrandId + " " +
					"Color Id:" + cars.ColorId + " " +
					"Model Year:" + cars.ModelYear + " " +
					"Daily Price:" + cars.DailyPrice + " " +
					"Description:" + cars.Description);
			}

			carManager.Delete(new Car { Id=7});

			Console.WriteLine("\nEklenen veriyi tekrar sildik\nDelete sonrası cagırma\n");

			foreach (var cars in carManager.GetAll())
			{
				Console.WriteLine(
					"Id:" + cars.Id + " " +
					"Yılı:" + cars.BrandId + " " +
					"Color Id:" + cars.ColorId + " " +
					"Model Year:" + cars.ModelYear + " " +
					"Daily Price:" + cars.DailyPrice + " " +
					"Description:" + cars.Description);
			}

		}
	}
}
