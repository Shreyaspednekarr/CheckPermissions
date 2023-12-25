using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission> Get(int permissionId);
        Task<bool> IsExists(CreatePermissionRequest request);
        Task<IEnumerable<Permission>> GetAll();
        Task Create(CreatePermissionRequest request);
        Task<bool> Delete(int permissionId);
        Task Assign(AssignPermissionRequest request);
    }
}
