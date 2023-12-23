namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IPermissionDal
    {
        Task Get(int userId);
        Task Create(string permissionName, int roleId);
        Task Delete(int permissionId);
        Task Assign(int permissionId, int userId);
    }
}
