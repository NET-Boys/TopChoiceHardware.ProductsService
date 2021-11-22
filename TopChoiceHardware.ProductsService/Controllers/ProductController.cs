using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Post(ProductDtoForCreation producto)
        {
            try
            {
                return new JsonResult(_service.CreateProduct(producto)) { StatusCode = 201 };

                //Agregar lo de images
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet] //Es getall, no se especifica
        [AllowAnonymous]
        public IActionResult GetAllProducts()
        {
            try
            {
                var productos = _service.GetAllProductDtoForDisplay();

                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("PriceSortedAsc")]
        [AllowAnonymous]
        public IActionResult GetAllProductsPriceSortedAsc()
        {
            try
            {
                var productos = _service.GetAllProducts();
                productos.Sort((x, y) => x.UnitPrice.CompareTo(y.UnitPrice));
                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("PriceSortedDesc")]
        [AllowAnonymous]
        public IActionResult GetAllProductsPriceSortedDesc()
        {
            try
            {
                var productos = _service.GetAllProducts();
                productos.Sort((x, y) => y.UnitPrice.CompareTo(x.UnitPrice));
                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]//por ID
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
