using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IUserDal
    {
        Task<User> Get(int userId);
        Task<bool> Get(CreateUserRequest request);
        Task<IEnumerable<User>> GetAll();
        Task Create(CreateUserRequest request);
        Task<bool> Delete(int userId);
    }
}
