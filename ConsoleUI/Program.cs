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
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			RentalManager rentalManager = new RentalManager(new EfRentDal());
			UserManager userManager = new UserManager(new EfUserDal());

			ColorAdded(colorManager);

			BrandAdded(brandManager);

			CarAdded(carManager);

			UserAdded(userManager);

			CustomerAdded(customerManager);

			RentalAdded(rentalManager);

		}

		private static void RentalAdded(RentalManager rentalManager)
		{
			rentalManager.Add(new Rental {CarId = 5, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = DateTime.Now });
			foreach (var rental in rentalManager.GetAll().Data)
			{
				Console.WriteLine(
					"Car Id:" + rental.CarId + " " +
					"Customer Id:" + rental.CustomerId + " " +
					"RentDate:" + rental.RentDate + " " +
					"Return Date:" + rental.RentDate + "\n");
			}
		}

		private static void BrandAdded(BrandManager brandManager)
		{
			brandManager.Add(new Brand { Name = "Audi" });

			foreach (var brand in brandManager.GetAll().Data)
			{
				Console.WriteLine("Id:"+brand.Id+"\n"+"Brand Name:" + brand.Name + "\n");
			}
		}

		private static void CarAdded(CarManager carManager)
		{
			carManager.Add(
							new Car
							{
								BrandId = 1,
								ColorId = 1,
								DailyPrice = 111,
								Description = "Satılık",
								ModelYear = 2019,
								Name = "Audi4"
							});

			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(
					"Id:" + car.Id + " " +
					"Brand Id:" + car.BrandId + " " +
					"Color Id:" + car.ColorId + " " +
					"DailyPrice:" + car.DailyPrice + " " +
					"Description:" + car.Description + " " +
					"ModelYear:" + car.ModelYear + " " +
					"Name:" + car.ModelYear + "\n");
			}
		}

		private static void ColorAdded(ColorManager colorManager)
		{
			colorManager.Add(new Color { Name = "Mavi" });

			foreach (var color in colorManager.GetAll().Data)
			{
				Console.WriteLine("Id:" + color.Id + "\n" + "Name:" + color.Name + "\n");
			}
		}

		private static void UserAdded(UserManager userManager)
		{
			userManager.Add(new User { FirstName = "kaan", LastName = "Akyüz", Email = "...@gmail.com", Password = "12345" });

			foreach (var user in userManager.GetAll().Data)
			{
				Console.WriteLine(

					"First Name:" + user.FirstName + " " +
					"Last Name:" + user.LastName + " " +
					"Email:" + user.Email + " " +
					"Password:" + user.Password + "\n");
			}
		}

		private static void CustomerAdded(CustomerManager customerManager)
		{
			var result = customerManager.Add(
							new Customer
							{
								UserId = 2,
								CompanyName = "Tesla"
							}

							);

			if (result.Success)
			{
				Console.WriteLine(result.Message);
				foreach (var customer in customerManager.GetAll().Data)
				{
					Console.WriteLine(
						"User Id:"+customer.UserId+"\n"+
						"Company Name:"+customer.CompanyName+"\n");
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}
	}
}
