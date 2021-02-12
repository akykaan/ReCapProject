using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext>,ICarDal // Entity Framework Car Dal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				var result = from c in context.Cars
							 join color in context.Colors
							 on c.ColorId equals color.Id
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 select new CarDetailDto
							 {
								 CarName = c.Name,
								 BrandName = b.Name,
								 ColorName = color.Name,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}
