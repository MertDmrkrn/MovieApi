﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

		public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
		{
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var value = await _getCategoryQueryHandler.Handle();
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _createCategoryCommandHandler.Handle(command);
			return Ok("Kategori Ekleme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
			return Ok("Kategori Silme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
		{
			await _updateCategoryCommandHandler.Handle(command);
			return Ok("Kategori Güncelleme İşlemi Başarıyla Gerçekleştirildi.");
		}

		[HttpGet("GetCategory")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
			return Ok(value);
		}
	}
}
