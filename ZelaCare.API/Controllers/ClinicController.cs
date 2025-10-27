using Microsoft.AspNetCore.Mvc;
using ZelaCare.Shared.Models.Clinics;
using ZelaCare.Application.Services;

namespace ZelaCare.API.Controllers
{
    [ApiController]
    [Route("clinic")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _service;
        public ClinicController(IClinicService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateClinincInputModel model)
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

        [HttpGet("cnpj/{cnpj}")]
        public async Task<IActionResult> GetByCnpj(string cnpj)
        {
            var result = await _service.GetByCnpjAsync(cnpj);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClinicInputModel model)
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
