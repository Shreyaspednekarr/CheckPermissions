using CheckPermissions.BusinessLayer.Services.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Implementation
{
    public class ApplicationService(IUnitOfWork unitOfWork) : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task<Service> Get(int serviceId)
        {
            return await _unitOfWork.Application.Get(serviceId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateApplicationRequest request)
        {
            return await _unitOfWork.Application.Get(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _unitOfWork.Application.GetAll().ConfigureAwait(false);
        }

        public async Task Create(CreateApplicationRequest request)
        {
            await _unitOfWork.Application.Create(request).ConfigureAwait(false);
        }

        public async Task Delete(int serviceId)
        {
            await _unitOfWork.Application.Delete(serviceId).ConfigureAwait(false);
        }
    }
}
