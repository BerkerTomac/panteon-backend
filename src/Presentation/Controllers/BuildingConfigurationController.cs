using Application.Interfaces;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/config")]
    [ApiController]
    public class BuildingConfigurationController : ControllerBase
    {
        private readonly IBuildingConfigurationService _service;

        public BuildingConfigurationController(IBuildingConfigurationService service)
        {
            _service = service;
        }

        [HttpGet("getconfig")]
        public async Task<ActionResult<IEnumerable<BuildingConfigurationDto>>> GetConfigurations()
        {
            var configurations = await _service.GetAllConfigurationsAsync();
            return Ok(configurations);
        }

        [HttpPost("addconfig")]
        public async Task<IActionResult> AddConfiguration([FromBody] BuildingConfigurationDto configurationDto)
        {
            try
            {
                var result = await _service.AddConfigurationAsync(configurationDto);
                if (result)
                {
                    return Ok("Configuration added successfully.");
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Failed to add configuration.");
        }

        [HttpGet("getavailable")]
        public async Task<ActionResult<IEnumerable<string>>> GetAvailableBuildingTypes()
        {
            var availableBuildingTypes = await _service.GetAvailableBuildingTypesAsync();
            return Ok(availableBuildingTypes);
        }
    }
}
