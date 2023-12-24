using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IApplicationDal
    {
        Task<Service> Get(int serviceId);
        Task<bool> Get(CreateApplicationRequest request);
        Task<IEnumerable<Service>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task Delete(int serviceId);
    }
}
