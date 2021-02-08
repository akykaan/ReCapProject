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
			Console.WriteLine("\n 7 nummara Id'li arabayı ekledik");
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

			Console.WriteLine("\nHata mesajı için günlük fiyatı 0'dan düşük veri ekledik");
			carManager.Add( 
				new Car
				{
					Id = 7,
					BrandId = 77,
					ColorId = 777,
					ModelYear = 1992,
					DailyPrice = -5123,// negatif değer
					Description = "Kiralık"
				});

			Console.WriteLine("\nHata mesajı için araba ismi 2 karakter olmayan veri ekledik");
			brandManager.Add(
				new Brand
				{
					BrandName = "K" // 
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

			Console.WriteLine("\n 7 Id'li eklenen veriyi tekrar sildik\nDelete sonrası cagırma\n");

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
