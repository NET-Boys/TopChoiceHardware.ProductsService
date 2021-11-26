using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TopChoiceHardware.Products.Application.Services;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        public IActionResult Post(CategoryDto categoria)
        {
            try
            {
                return new JsonResult(_service.CreateCategory(categoria)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categorias = _service.GetAllCategoryDtosForDisplay();

                return Ok(categorias);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var categoria = _service.GetCategoryDtoForDisplayById(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
