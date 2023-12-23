using CheckPermissions.BusinessLayer.Services.Interfaces;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class PermissionService : IPermissionService
    {
        public PermissionService() { }

        public async Task Get(int userId)
        {

        }

        public async Task Create(string permissionName, int roleId)
        {

        }

        public async Task Delete(int permissionId)
        {

        }

        public async Task Assign(int permissionId, int userId)
        {

        }
    }
}
