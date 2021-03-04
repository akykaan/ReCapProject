using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarImagesController : ControllerBase
	{
		ICarImageService _carImagesService;

		public CarImagesController(ICarImageService carImagesService)
		{
			_carImagesService = carImagesService;
		}

		[HttpGet("add")]
		public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImages)
		{
			var result = _carImagesService.Add(file,carImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("update")]
		public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
		{
			var carImages = _carImagesService.Get(Id).Data;
			var result = _carImagesService.Update(file,carImages);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("delete")]
		public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
		{

			var carImage = _carImagesService.Get(Id).Data;

			var result = _carImagesService.Delete(carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carImagesService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcarbyıdımages")]
		public IActionResult GetCarByIdImages(int id)
		{
			var result = _carImagesService.GetCarByIdImages(id);

			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result);
		}
	}
}
