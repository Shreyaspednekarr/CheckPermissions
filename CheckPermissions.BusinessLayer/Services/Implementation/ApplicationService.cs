using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class ApplicationService(IUnitOfWork unitOfWork) : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Application> Get(int applicationId)
        {
            return await _unitOfWork.Application.Get(applicationId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateApplicationRequest request)
        {
            return await _unitOfWork.Application.Get(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _unitOfWork.Application.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreateApplicationRequest request)
        {
            await _unitOfWork.Application.Create(request).ConfigureAwait(false);
        }

        public async Task Delete(int applicationId)
        {
            await _unitOfWork.Application.Delete(applicationId).ConfigureAwait(false);
        }
    }
}
