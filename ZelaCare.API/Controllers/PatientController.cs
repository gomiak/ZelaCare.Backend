using Microsoft.AspNetCore.Mvc;
using ZelaCare.Application.Models.Patients;
using ZelaCare.Application.Services;

namespace ZelaCare.API.Controllers
{
    [ApiController]
    [Route("patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreatePatientInputModel model)
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

            if (!result.IsSuccess)
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

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var result = await _service.GetByCpfAsync(cpf);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _service.GetByEmailAsync(email);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name, [FromQuery] Guid clinicId)
        {
            var result = await _service.SearchByNameAsync(name, clinicId);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePatientInputModel model)
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
