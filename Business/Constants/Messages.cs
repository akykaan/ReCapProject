using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		

		//car messages
		public static string CarNameInvalid = "Günlük fiyatı 0'dan büyük giriniz!";
		public static string CarAdded = "Car Başarıyla Eklendi";
		public static string CarUpdated = "Car Başarıyla Güncellendi";
		public static string CarDeleted = "Car Başarıyla silindi";
		public static string CarListed = "Car listelendi";
		// color		
		public static string ColorAdded = "Color Başarıyla Eklendi";
		public static string ColorDeleted = "Color Başarıyla silindi";
		public static string ColorUpdated = "Color Başarıyla Güncellendi";
		public static string ColorListed = "Color listelendi";

		//other
		public static string MaintenanceTime = "Sistem bakımda";
		public static string ProductsListed = "Ürünler listelendi";
		public static string ProductUpdated = "Güncellendi";
		public static string ProductAdded = "Ürün Eklendi";

		//brand
		public static string BrandNameInvalid = "Araba ismi minimum 2 karakter olmalıdır.";
		public static string BrandDeleted = "Brand Başarıyla silindi";
		public static string BrandAdded = "Brand Başarıyla Eklendi";

		//rental
		public static string RentalAddedError = "Rental Eklemedi";
		public static string RentalAdded = "Rental Eklemedi";
		public static string RentalDeleted = "Rental Silindi";
		public static string RentalUpdated = "Rental Güncellendi";

		//User
		public static string UserAdded = "User Eklendi";
		public static string UserDeleted = "User Silindi";
		public static string UserUpdated = "User Güncellendi";

		//customer
		public static string CustomerAdded = "Customer Eklendi";
		public static string CustomerDeleted = "Customer Silindi";
		public static string CustomerUpdated = "Customer Güncellendi";
		public static string CustomerListed = "Customer listelendi";

		public static string CarImageAdded = "Image eklendi";

		public static string CarImageLimitError = "araba resmi 5den büyük olamaz.";
	}
}
