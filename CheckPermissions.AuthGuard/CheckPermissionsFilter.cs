using CheckPermissions.DataAccessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CheckPermissions.AuthGuard
{
    public class CheckPermissionsFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CheckPermissionsFilter(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor actionDescriptor)
            {
                var methodInfo = actionDescriptor.MethodInfo;

                if (methodInfo.GetCustomAttributes(typeof(CheckPermissions), inherit: true).FirstOrDefault() is CheckPermissions checkPermissionsAttribute)
                {
                    string applicationName = checkPermissionsAttribute.ApplicationName;
                    string permissionName = checkPermissionsAttribute.PermissionName;

                    //Get the current user ID from httpContext
                    var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    //Perform permission check
                    var hasPermission = await CheckPermission(applicationName, permissionName, currentUserId).ConfigureAwait(false);

                    if (!hasPermission)
                    {
                        context.Result = new UnauthorizedObjectResult("Unauthorized: You don't have permission to access this resource.");
                    }
                }
            }
        }

        private async Task<bool> CheckPermission(string applicationName, string permissionName, string userId)
        {
            var hasPermission = await _unitOfWork.User.CheckPermission(applicationName, permissionName, userId).ConfigureAwait(false);
            return hasPermission;
        }
    }
}
