using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elessi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // GET: api/<SliderController>
        [HttpPost("Add")]
        public IActionResult Add(SliderDTO sliderDTO )
        {
            var result = _sliderService.Add(sliderDTO);
            if (result.Success) return Ok(new { status = 200, message=result.Message });
            return BadRequest(new { message = result.Message });
        }

        // GET api/<SliderController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _sliderService.GetById(id);
            if (result.Success) return Ok(new { status = 200, data=result.Data });
            return BadRequest(new { message = result.Message });

        }

        // POST api/<SliderController>
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _sliderService.GetAll();
            if (result.Success) return Ok(new { status = 200, data = result.Data });
            return BadRequest(new { message = result.Message });
        }

        // PUT api/<SliderController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SliderDTO sliderDTO )
        {
            var result = _sliderService.Update(id, sliderDTO);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }

        // DELETE api/<SliderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _sliderService.Delete(id);
            if (result.Success) return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }
    }
}
