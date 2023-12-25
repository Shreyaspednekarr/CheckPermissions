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

        [HttpGet("Get/{applicationId}")]
        [ProducesResponseType(typeof(Application), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int applicationId)
        {
            try
            {
                var result = await _applicationService.Get(applicationId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<Application>), StatusCodes.Status200OK)]
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
                var exists = await _applicationService.IsExists(request).ConfigureAwait(false);
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

        [HttpGet("Delete/{applicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int applicationId)
        {
            try
            {
                var deleted = await _applicationService.Delete(applicationId).ConfigureAwait(false);
                if (deleted)
                {
                    return Ok("Application deleted successfully!");
                }
                return BadRequest("Application doesn't exist!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
