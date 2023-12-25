using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class ApplicationDal(CheckPermissionsDbModel dbModel) : IApplicationDal
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public async Task<Application> Get(int applicationId)
        {
            return await _dbModel.Applications.FirstOrDefaultAsync(x => x.Id == applicationId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateApplicationRequest request)
        {
            return _dbModel.Applications.Any(x => x.ApplicationName.ToLower() == request.ApplicationName.ToLower());
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _dbModel.Applications.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreateApplicationRequest request)
        {
            Application application = new()
            {
                ApplicationName = request.ApplicationName.ToLower(),
                Description = request.Description
            };
            await _dbModel.Applications.AddAsync(application).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> Delete(int applicationId)
        {
            var application = await _dbModel.Applications
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync(x => x.Id == applicationId).ConfigureAwait(false);

            if (application != null)
            {
                if (application.Permissions.Count != 0)
                {
                    foreach (var permission in application.Permissions)
                    {
                        var userPermissions = await _dbModel.UserPermissions.Where(x => x.PermissionId == permission.Id).ToListAsync().ConfigureAwait(false);
                        var rolePermissions = await _dbModel.RolePermissions.Where(x => x.PermissionId == permission.Id).ToListAsync().ConfigureAwait(false);

                        _dbModel.UserPermissions.RemoveRange(userPermissions);
                        _dbModel.RolePermissions.RemoveRange(rolePermissions);
                    }
                    _dbModel.Permissions.RemoveRange(application.Permissions);
                }
                _dbModel.Applications.Remove(application);
                await _dbModel.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }
    }
}
