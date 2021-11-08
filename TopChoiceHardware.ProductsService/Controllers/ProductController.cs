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

namespace TopChoiceHardware.ProductsService.Controllers
{
    [Route("api/products")]
    [ApiController]
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
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet] //Es getall, no se especifica
        public IActionResult GetAllProducts()
        {
            try
            {
                var productos = _service.GetProductos();

                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("PriceSortedAsc")]
        public IActionResult GetAllProductsPriceSortedAsc()
        {
            try
            {
                var productos = _service.GetProductos();
                productos.Sort((x, y) => x.UnitPrice.CompareTo(y.UnitPrice));
                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("PriceSortedDesc")]
        public IActionResult GetAllProductsPriceSortedDesc()
        {
            try
            {
                var productos = _service.GetProductos();
                productos.Sort((x, y) => y.UnitPrice.CompareTo(x.UnitPrice));
                return Ok(productos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")] //por ID
        public IActionResult GetProductById(int id)
        {
            try
            {
                var producto = _service.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }

                return Ok(producto);
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
        public IActionResult UpdateProduct(int id, [FromBody] ProductDtoForCreation product) //Es dto porque los datos mostrados en la app son dtos
        {
            if (product== null)
            {
                return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
            }
            var productEntity = _service.GetProductoById(id); //Se obtiene el product en la db

            if (productEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(product, productEntity); //mapea el pasado por parametro a la entidad en DB
            _service.UpdateProduct(productEntity);

            return NoContent();
        }
    }
}
