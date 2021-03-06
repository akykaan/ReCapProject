﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImagesDal;
		public CarImageManager(ICarImageDal carImages)
		{
			_carImagesDal = carImages;
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Add(IFormFile file, CarImage carImages)
		{
			IResult result = BusinessRules.Run(CheckCarImageLimit(carImages.CarId));
			if (result!=null)
			{
				return result;
			}
			carImages.ImagePath = FileHelper.Add(file);
			carImages.Date = DateTime.Now;
			_carImagesDal.Add(carImages);
			return new SuccessResult();
		}
		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Delete(CarImage carImages)
		{
			FileHelper.Delete(carImages.ImagePath);
			_carImagesDal.Delete(carImages);
			return new SuccessResult();
		}

		public IDataResult<CarImage> Get(int id)
		{
			return new SuccessDataResult<CarImage>(_carImagesDal.Get(p => p.Id == id));
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(),Messages.CarImageAdded);
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IDataResult<List<CarImage>> GetCarByIdImages(int id)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
			if (result != null)
			{
				return new ErrorDataResult<List<CarImage>>(result.Message);
			}

			return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
		}

		public IResult Update(IFormFile file, CarImage carImages)
		{
			IResult result = BusinessRules.Run(CheckCarImageLimit(carImages.CarId));
			if (result != null)
			{
				return result;
			}
			carImages.ImagePath = FileHelper.Update(_carImagesDal.Get(p => p.Id == carImages.Id).ImagePath, file);
			carImages.Date = DateTime.Now;
			_carImagesDal.Update(carImages);
			return new SuccessResult();
		}


		private IResult CheckCarImageLimit(int carId)
		{
			var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
			if (result>=5)
			{
				return new ErrorResult(Messages.CarImageLimitError);
			}
			return new SuccessResult();
		}

		private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
		{			
			try
			{
				string path = @"\wwwroot\uploads\defaultlogo.jpg";
				var result = _carImagesDal.GetAll(c => c.CarId == id).Any();
				if (!result)
				{
					List<CarImage> carimage = new List<CarImage>();
					carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
					return new SuccessDataResult<List<CarImage>>(carimage);
				}
			}
			catch (Exception exception)
			{

				return new ErrorDataResult<List<CarImage>>(exception.Message);
			}
			return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(p => p.CarId == id).ToList());
		}
	}
}