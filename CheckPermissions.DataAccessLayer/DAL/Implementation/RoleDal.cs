using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class RoleDal(CheckPermissionsDbModel dbModel) : IRoleDal
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public async Task<Role> Get(int userId)
        {
            return await _dbModel.Roles.FirstOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateRoleRequest request)
        {
            return _dbModel.Roles.Any(x => x.Name.ToLower() == request.RoleName.ToLower());
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _dbModel.Roles.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreateRoleRequest request)
        {
            Role role = new()
            {
                Name = request.RoleName,
                Description = request.Description,
            };
            await _dbModel.Roles.AddAsync(role).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int roleId)
        {
            var role = await _dbModel.Roles.FirstOrDefaultAsync(x => x.Id == roleId).ConfigureAwait(false);
            if (role != null)
            {
                _dbModel.Roles.Remove(role);
            }
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Assign(int roleId, int userId)
        {

        }
    }
}
