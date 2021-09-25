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
    public class SupplierController : ControllerBase
    {
        private readonly IProveedorService _service;

        public SupplierController(IProveedorService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Proveedor), StatusCodes.Status201Created)]
        public IActionResult Post(ProveedorDto proveedor)
        {
            try
            {
                return new JsonResult(_service.CreateProveedor(proveedor)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAlSuppliers()
        {
            try
            {
                var proveedores = _service.GetProveedores();

                return Ok(proveedores);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            try
            {
                var proveedor = _service.GetProveedorById(id);
                if (proveedor == null)
                {
                    return NotFound();
                }

                return Ok(proveedor);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
