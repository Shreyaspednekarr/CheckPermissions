using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IApplicationDal
    {
        Task<Application> Get(int applicationId);
        Task<bool> Get(CreateApplicationRequest request);
        Task<IEnumerable<Application>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task Delete(int applicationId);
    }
}
