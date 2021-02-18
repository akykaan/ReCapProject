﻿using Business.Constants;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
			if(car.DailyPrice>0)
			{
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
			}
			else
			{
				return new ErrorResult(Messages.CarNameInvalid);
				//Console.WriteLine("günlük fiyatı 0'dan büyük giriniz!");
			}

		}

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

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
		}
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
	}
}
