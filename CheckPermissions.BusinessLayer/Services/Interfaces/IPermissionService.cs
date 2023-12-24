using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission> Get(int userId);
        Task<bool> Get(CreatePermissionRequest request);
        Task<IEnumerable<Permission>> GetAll();
        Task Create(CreatePermissionRequest request);
        Task Delete(int permissionId);
        Task Assign(int permissionId, int userId);
    }
}
