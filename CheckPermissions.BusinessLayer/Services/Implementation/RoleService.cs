using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class RoleService(IUnitOfWork unitOfWork) : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Role> Get(int userId)
        {
            return await _unitOfWork.Role.Get(userId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateRoleRequest request)
        {
            return await _unitOfWork.Role.Get(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _unitOfWork.Role.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreateRoleRequest request)
        {
            await _unitOfWork.Role.Create(request).ConfigureAwait(false);
        }

        public async Task Delete(int roleId)
        {
            await _unitOfWork.Role.Delete(roleId).ConfigureAwait(false);
        }

        public async Task Assign(AssignRoleRequest request)
        {
            await _unitOfWork.Role.Assign(request).ConfigureAwait(false);
        }
    }
}
