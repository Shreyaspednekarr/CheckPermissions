namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IRoleDal
    {
        Task Get(int userId);
        Task Create(string roleName);
        Task Delete(int roleId);
        Task Assign(int roleId, int userId);
    }
}
