using CheckPermissions.DataAccessLayer.DAL.Interfaces;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class PermissionDal : IPermissionDal
    {
        public PermissionDal() { }

        public async Task Get(int userId)
        {

        }

        public async Task Create(string permissionName, int roleId)
        {

        }

        public async Task Delete(int permissionId)
        {

        }

        public async Task Assign(int permissionId, int userId)
        {

        }
    }
}
