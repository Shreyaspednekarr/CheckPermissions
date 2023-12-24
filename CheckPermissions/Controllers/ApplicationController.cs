using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController(IApplicationService applicationService) : ControllerBase
    {
        private readonly IApplicationService _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));

        [HttpGet("Get/{serviceId}")]
        [ProducesResponseType(typeof(Service), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int serviceId)
        {
            try
            {
                var result = await _applicationService.Get(serviceId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<Service>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _applicationService.GetAll().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([Required][FromBody] CreateApplicationRequest request)
        {
            try
            {
                var exists = await _applicationService.Get(request).ConfigureAwait(false);
                if (exists)
                {
                    return BadRequest("Application name already exists!");
                }
                await _applicationService.Create(request).ConfigureAwait(false);
                return Ok("Application name created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Delete/{serviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int serviceId)
        {
            try
            {
                await _applicationService.Delete(serviceId).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
