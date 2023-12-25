using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class PermissionDal(CheckPermissionsDbModel dbModel) : IPermissionDal
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public async Task<Permission> Get(int permissionId)
        {
            return await _dbModel.Permissions.FirstOrDefaultAsync(x => x.Id == permissionId).ConfigureAwait(false);
        }

        public async Task<bool> IsExists(CreatePermissionRequest request)
        {
            return _dbModel.Permissions.Any(x => x.PermissionName.ToLower() == request.PermissionName.ToLower());
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _dbModel.Permissions.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreatePermissionRequest request)
        {
            Permission permission = new()
            {
                ApplicationId = request.ApplicationId,
                PermissionName = request.PermissionName,
                Description = request.Description
            };
            await _dbModel.Permissions.AddAsync(permission).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> Delete(int permissionId)
        {
            var permission = await _dbModel.Permissions
                .FirstOrDefaultAsync(x => x.Id == permissionId).ConfigureAwait(false);

            if (permission != null)
            {
                var userPermissions = await _dbModel.UserPermissions.Where(x => x.PermissionId == permission.Id).ToListAsync().ConfigureAwait(false);
                var rolePermissions = await _dbModel.RolePermissions.Where(x => x.PermissionId == permission.Id).ToListAsync().ConfigureAwait(false);

                _dbModel.UserPermissions.RemoveRange(userPermissions);
                _dbModel.RolePermissions.RemoveRange(rolePermissions);
                _dbModel.Permissions.Remove(permission);
                await _dbModel.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        public async Task Assign(AssignPermissionRequest request)
        {

        }
    }
}
