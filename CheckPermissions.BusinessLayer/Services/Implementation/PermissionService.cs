using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class PermissionService(IUnitOfWork unitOfWork) : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Permission> Get(int permissionId)
        {
            return await _unitOfWork.Permission.Get(permissionId).ConfigureAwait(false);
        }

        public async Task<bool> IsExists(CreatePermissionRequest request)
        {
            return await _unitOfWork.Permission.IsExists(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _unitOfWork.Permission.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreatePermissionRequest request)
        {
            await _unitOfWork.Permission.Create(request).ConfigureAwait(false);
        }

        public async Task<bool> Delete(int permissionId)
        {
            return await _unitOfWork.Permission.Delete(permissionId).ConfigureAwait(false);
        }

        public async Task Assign(AssignPermissionRequest request)
        {
            await _unitOfWork.Permission.Assign(request).ConfigureAwait(false);
        }
    }
}
