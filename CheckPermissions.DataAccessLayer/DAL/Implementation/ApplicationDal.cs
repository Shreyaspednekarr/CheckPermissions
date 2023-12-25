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

        public async Task<Application> Get(int applicationId)
        {
            return await _dbModel.Applications.FirstOrDefaultAsync(x => x.Id == applicationId).ConfigureAwait(false);
        }

        public async Task<bool> Get(CreateApplicationRequest request)
        {
            return _dbModel.Applications.Any(x => x.ApplicationName.ToLower() == request.ApplicationName.ToLower());
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _dbModel.Applications.ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(CreateApplicationRequest request)
        {
            Application application = new()
            {
                ApplicationName = request.ApplicationName.ToLower(),
                Description = request.Description
            };
            await _dbModel.Applications.AddAsync(application).ConfigureAwait(false);
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int applicationId)
        {
            var service = await _dbModel.Applications.FirstOrDefaultAsync(x => x.Id == applicationId).ConfigureAwait(false);
            if (service != null)
            {
                _dbModel.Applications.Remove(service);
            }
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
