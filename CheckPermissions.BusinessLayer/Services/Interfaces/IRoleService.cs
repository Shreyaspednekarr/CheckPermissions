namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IRoleService
    {
        Task Get(int userId);
        Task Create(string roleName);
        Task Delete(int roleId);
        Task Assign(int roleId, int userId);
    }
}
