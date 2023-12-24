using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository;
using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;
using Microsoft.EntityFrameworkCore;

namespace CheckPermissions.DataAccessLayer.DAL.Implementation
{
    public class ApplicationDal(CheckPermissionsDbModel dbModel) : IApplicationDal
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public async Task<Service> Get(int serviceId)
        {
            return await _dbModel.Services.FirstOrDefaultAsync(x => x.Id == serviceId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateApplicationRequest request)
        {
            return _dbModel.Services.Any(x => x.Name.ToLower() == request.ApplicationName.ToLower());
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _dbModel.Services.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreateApplicationRequest request)
        {
            Service service = new()
            {
                Name = request.ApplicationName.ToLower(),
                Description = request.Description
            };
            await _dbModel.Services.AddAsync(service).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int serviceId)
        {
            var service = await _dbModel.Services.FirstOrDefaultAsync(x => x.Id == serviceId).ConfigureAwait(false);
            if (service != null)
            {
                _dbModel.Services.Remove(service);
            }
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
