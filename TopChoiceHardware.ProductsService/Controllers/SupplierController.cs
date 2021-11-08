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
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status201Created)]
        public IActionResult Post(SupplierDto proveedor)
        {
            try
            {
                return new JsonResult(_service.CreateSupplier(proveedor)) { StatusCode = 201 };
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
                var proveedores = _service.GetSuppliers();

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
                var proveedor = _service.GetSupplierById(id);
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
