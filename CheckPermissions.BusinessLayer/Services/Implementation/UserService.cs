using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<User> Get(int userId)
        {
            return await _unitOfWork.User.Get(userId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateUserRequest request)
        {
            return await _unitOfWork.User.Get(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.User.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreateUserRequest request)
        {
            await _unitOfWork.User.Create(request).ConfigureAwait(false);
        }

        public async Task Delete(int userId)
        {
            await _unitOfWork.User.Delete(userId).ConfigureAwait(false);
        }
    }
}
