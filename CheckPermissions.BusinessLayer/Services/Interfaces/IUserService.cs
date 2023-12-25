using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(int userId);
        Task<bool> Get(CreateUserRequest request);
        Task<IEnumerable<User>> GetAll();
        Task Create(CreateUserRequest request);
        Task Delete(int userId);
    }
}
