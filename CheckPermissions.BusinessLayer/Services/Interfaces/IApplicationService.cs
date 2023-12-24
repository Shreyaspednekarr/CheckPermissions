using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Service> Get(int serviceId);
        Task<bool> Get(CreateApplicationRequest request);
        Task<IEnumerable<Service>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task Delete(int serviceId);
    }
}
