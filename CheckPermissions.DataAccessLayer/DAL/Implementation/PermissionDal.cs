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

        public async Task<Permission> Get(int userId)
        {
            return await _dbModel.Permissions.FirstOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreatePermissionRequest request)
        {
            return _dbModel.Permissions.Any(x => x.Name.ToLower() == request.PermissionName.ToLower());
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _dbModel.Permissions.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreatePermissionRequest request)
        {
            Permission permission = new()
            {
                ServiceId = request.ServiceId,
                Name = request.PermissionName,
                Description = request.Description
            };
            await _dbModel.Permissions.AddAsync(permission).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int permissionId)
        {
            var permission = await _dbModel.Permissions.FirstOrDefaultAsync(x => x.Id == permissionId).ConfigureAwait(false);
            if (permission != null)
            {
                _dbModel.Permissions.Remove(permission);
            }
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Assign(int permissionId, int userId)
        {

        }
    }
}
