using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CheckPermissions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        [HttpGet("Get/{userId}")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var result = await _roleService.Get(userId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _roleService.GetAll().ConfigureAwait(false);
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
        public async Task<IActionResult> Create([Required][FromBody] CreateRoleRequest request)
        {
            try
            {
                var exists = await _roleService.Get(request).ConfigureAwait(false);
                if (exists)
                {
                    return BadRequest("Role already exists!");
                }
                await _roleService.Create(request).ConfigureAwait(false);
                return Ok("Role created successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Delete/{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int roleId)
        {
            try
            {
                var deleted = await _roleService.Delete(roleId).ConfigureAwait(false);
                if (deleted)
                {
                    return Ok("Role deleted successfully!");
                }
                return BadRequest("Role doesn't exist!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Assign([Required][FromBody] AssignRoleRequest request)
        {
            try
            {
                await _roleService.Assign(request).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
