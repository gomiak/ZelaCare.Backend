using Microsoft.AspNetCore.Mvc;
using ZelaCare.Shared.Models.Professionals;
using ZelaCare.Core.Enums;
using ZelaCare.Application.Services;

namespace ZelaCare.API.Controllers
{
    [ApiController]
    [Route("professional")]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalService _service;

        public ProfessionalController(IProfessionalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProfessionalInputModel model)
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var result = await _service.GetByUserIdAsync(userId);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("clinic/{clinicId}")]
        public async Task<IActionResult> GetByClinicId(Guid clinicId)
        {
            var result = await _service.GetByClinicIdAsync(clinicId);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("specialty/{specialty}")]
        public async Task<IActionResult> GetBySpecialty(Specialty specialty)
        {
            var result = await _service.GetBySpecialtyAsync(specialty);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProfessionalInputModel model)
        {
            var result = await _service.UpdateAsync(id, model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }
    }
}
