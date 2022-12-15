using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elessi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/<SliderController>
        [HttpPost("Add")]
        public IActionResult Add(BlogDTO blogDTO)
        {
            var result = _blogService.Add(blogDTO);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }

        // GET api/<SliderController>/5
        [HttpGet("Get/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _blogService.GetById(id);
            if (result.Success) return Ok(new { status = 200, data = result.Data });
            return BadRequest(new { message = result.Message });

        }

        // POST api/<SliderController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _blogService.GetAll();
            if (result.Success) return Ok(new { status = 200, data = result.Data });
            return BadRequest(new { message = result.Message });
        }

        // PUT api/<SliderController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] BlogDTO blogDTO)
        {
            var result = _blogService.Update(id, blogDTO);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }

        // DELETE api/<SliderController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _blogService.Delete(id);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }
    }
}
