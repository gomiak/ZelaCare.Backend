using Microsoft.AspNetCore.Mvc;
using ZelaCare.Application.Models.Users;
using ZelaCare.Application.Services;

namespace ZelaCare.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) 
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUserInputModel model) 
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            if(!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("clinic/{clinicId:guid}")]
        public async Task<IActionResult> GetByClinicId(Guid clinicId)
        {
            var result = await _service.GetByClinicIdAsync(clinicId);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserInputModel model)
        {
            var result = await _service.UpdateAsync(id, model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return NoContent();
        }
    }
}
