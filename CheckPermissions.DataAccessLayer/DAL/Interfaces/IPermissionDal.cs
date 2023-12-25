using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IPermissionDal
    {
        Task<Permission> Get(int userId);
        Task<bool> Get(CreatePermissionRequest request);
        Task<IEnumerable<Permission>> GetAll();
        Task Create(CreatePermissionRequest request);
        Task<bool> Delete(int permissionId);
        Task Assign(int permissionId, int userId);
    }
}
