using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}


		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);
			//if (brand.Name.Length >= 2)
			//{
				
			//}
				
			//else
			//{
			//	return new ErrorResult(Messages.BrandNameInvalid);
			//	//Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
			//}
				
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Messages.ProductAdded);
			//if (brand.Name.Length >= 2)
			//{
				
			//}
				
			//else
			//{
			//	return new ErrorResult(Messages.BrandNameInvalid);
			//	//Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
			//}
				
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.BrandDeleted);

		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.ProductsListed);
		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
		}
		
	}
}