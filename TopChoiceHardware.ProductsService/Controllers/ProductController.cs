using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using TopChoiceHardware.Products.Application.Services;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TopChoiceHardware.ProductsService.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post(ProductDtoForCreation producto)
        {
            try
            {
                return new JsonResult(_service.CreateProduct(producto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllProducts(string order=null)
        {
            try
            {
                if (order != null)
                {
                    var ListProductsDto = _service.GetProductDtoForDisplaysSortedByUnitPrice(order);

                    if (ListProductsDto == null)
                    {
                        return new JsonResult(new ProductNotFoundResponse()) { StatusCode = 404 };
                    }

                    return Ok(ListProductsDto);
                }
                else
                {
                    var productos = _service.GetAllProductDtoForDisplay();

                    return Ok(productos);
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var productDto = _service.GetProductDtoForDisplayById(id);

                if (productDto == null)
                {
                    return new JsonResult(new ProductNotFoundResponse()) { StatusCode = 404 };
                }

                return Ok(productDto);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            try
            {
                var productDto = _service.GetAllProductDtoForDisplayByCategoryId(categoryId);

                if (productDto == null)
                {
                    return new JsonResult(new ProductNotFoundResponse()) { StatusCode = 404 };
                }
                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("supplier/{supplierId}")]
        [AllowAnonymous]
        public IActionResult GetProductBySupplierId(int supplierId)
        {
            try
            {
                var productDto = _service.GetAllProductDtoForDisplaysBySupplierId(supplierId);

                if (productDto == null)
                {
                    return new JsonResult(new ProductNotFoundResponse()) { StatusCode = 404 };
                }
                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDtoForCreation productDto) //Es dto porque los datos mostrados en la app son dtos
        {
            if (productDto == null)
            {
                return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
            }
            var productEntity = _service.GetProductById(id); //Se obtiene el product en la db

            if (productEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(productDto, productEntity); //mapea el pasado por parametro a la entidad en DB
            _service.UpdateProduct(productEntity);

            return NoContent();
        }
    }
}
