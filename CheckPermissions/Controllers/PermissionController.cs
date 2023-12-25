using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(IPermissionService permissionService) : ControllerBase
    {
        private readonly IPermissionService _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));

        [HttpGet("Get/{userId}")]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var result = await _permissionService.Get(userId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<Permission>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _permissionService.GetAll().ConfigureAwait(false);
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
        public async Task<IActionResult> Create([Required][FromBody] CreatePermissionRequest request)
        {
            try
            {
                var exists = await _permissionService.Get(request).ConfigureAwait(false);
                if (exists)
                {
                    return BadRequest("Permission already exists!");
                }
                await _permissionService.Create(request).ConfigureAwait(false);
                return Ok("Permission created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Delete/{permissionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int permissionId)
        {
            try
            {
                var deleted = await _permissionService.Delete(permissionId).ConfigureAwait(false);
                if (deleted)
                {
                    return Ok("Permission deleted successfully!");
                }
                return BadRequest("Permission doesn't exist!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Assign/{permissionId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Assign(int permissionId, int userId)
        {
            try
            {
                await _permissionService.Assign(permissionId, userId).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
