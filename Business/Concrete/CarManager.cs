using Business.Constants;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Business.BusinessAspects.Autofac;
using Core.Utilities.BusinessRules;
using System.Threading;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[SecuredOperation("car.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			//IResult result = BusinessRules.Run(CheckIfColorName(car.Name));

			//if (result!=null)
			//{
			//	return result;
			//}
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("IProductService.Get")]

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		[PerformanceAspect(5)]
		[CacheAspect]
		[SecuredOperation("admin")]
		public IDataResult<List<Car>> GetAll()
		{
			Thread.Sleep(5000);
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
		}

		[CacheAspect]
		public IDataResult<List<Car>> GetById(int Id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == Id));
		}
		
		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			_carDal.Update(car);
			_carDal.Add(car);
			return new SuccessResult(Messages.ProductUpdated);
			//Add(product);
			//if (product.UnitPrice<10)
			//{
			//	throw new Exception("");
			//}
			//Add(product);

			//return null;
		}
	}
}
