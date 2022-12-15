using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elessi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<SliderController>
        [HttpPost("Add")]
        public IActionResult Add(AddProductDTO productDTO)
        {
            var result = _productService.Add(productDTO);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new {message= result.Message});
        }

        // GET api/<SliderController>/5
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success) return Ok(new { status = 200, data = result.Data });
            return BadRequest(new { message = result.Message });
        }

        // POST api/<SliderController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success) return Ok(new { status = 200, data = result.Data });
            return BadRequest(new { message = result.Message });
        }

        // PUT api/<SliderController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] AddProductDTO productDTO)
        {
            var result = _productService.Update(id, productDTO);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }

        // DELETE api/<SliderController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.Success) Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }


    }
}

