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

        public async Task<bool> Get(CreateUserRequest request)
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
    }
}
