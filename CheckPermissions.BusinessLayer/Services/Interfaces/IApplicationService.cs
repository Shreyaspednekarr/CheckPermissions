using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> Get(int applicationId);
        Task<bool> IsExists(CreateApplicationRequest request);
        Task<IEnumerable<Application>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task<bool> Delete(int applicationId);
    }
}
