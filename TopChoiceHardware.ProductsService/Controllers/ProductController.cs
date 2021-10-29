using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopChoiceHardware.Products.Application.Services;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductController(IProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
        public IActionResult Post(ProductoDto producto)
        {
            try
            {
                return new JsonResult(_service.CreateProducto(producto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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
    }
}
