using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class UserDal(CheckPermissionsDbModel dbModel) : IUserDal
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public async Task<User> Get(int userId)
        {
            return await _dbModel.Users.FirstOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false);
        }

        public async Task<bool> IsExists(CreateUserRequest request)
        {
            return _dbModel.Users.Any(x => x.UserName.ToLower() == request.UserName.ToLower());
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbModel.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreateUserRequest request)
        {
            User user = new()
            {
                UserName = request.UserName.ToLower()
            };
            await _dbModel.Users.AddAsync(user).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> Delete(int userId)
        {
            var user = await _dbModel.Users
                .FirstOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false);

            if (user != null)
            {
                var userRoles = await _dbModel.UserRoles.Where(x => x.UserId == user.Id).ToListAsync().ConfigureAwait(false);
                var userPermissions = await _dbModel.UserPermissions.Where(x => x.UserId == user.Id).ToListAsync().ConfigureAwait(false);

                _dbModel.UserRoles.RemoveRange(userRoles);
                _dbModel.UserPermissions.RemoveRange(userPermissions);
                _dbModel.Users.Remove(user);
                await _dbModel.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        public async Task<bool> CheckPermission(string applicationName, string permissionName, string userId)
        {
            var application = await _dbModel.Applications.FirstOrDefaultAsync(x => x.ApplicationName.ToLower() == applicationName.ToLower()).ConfigureAwait(false);
            if (application != null)
            {
                var permission = await _dbModel.Permissions.FirstOrDefaultAsync(x => x.PermissionName.ToLower() == permissionName.ToLower()).ConfigureAwait(false);
                if (permission != null)
                {
                    var userPermission = await _dbModel.UserPermissions.FirstOrDefaultAsync(x => x.UserId == Convert.ToInt32(userId) && x.PermissionId == permission.Id).ConfigureAwait(false);
                    if (userPermission != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
