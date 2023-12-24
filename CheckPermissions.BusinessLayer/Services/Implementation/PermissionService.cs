using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class PermissionService(IUnitOfWork unitOfWork) : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Permission> Get(int userId)
        {
            return await _unitOfWork.Permission.Get(userId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreatePermissionRequest request)
        {
            return await _unitOfWork.Permission.Get(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _unitOfWork.Permission.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreatePermissionRequest request)
        {
            await _unitOfWork.Permission.Create(request).ConfigureAwait(false);
        }

        public async Task Delete(int permissionId)
        {
            await _unitOfWork.Permission.Delete(permissionId).ConfigureAwait(false);
        }

        public async Task Assign(int permissionId, int userId)
        {
            await _unitOfWork.Permission.Assign(permissionId, userId).ConfigureAwait(false);
        }
    }
}
