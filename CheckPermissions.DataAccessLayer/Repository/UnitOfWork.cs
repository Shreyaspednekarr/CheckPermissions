using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;

namespace CheckPermissions.DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CheckPermissionsDbModel _dbModel;

        public UnitOfWork(CheckPermissionsDbModel dbModel, IApplicationDal application, IPermissionDal permission, IRoleDal role)
        {
            _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Permission = permission ?? throw new ArgumentNullException(nameof(permission));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }

        public IApplicationDal Application { get; set; }
        public IPermissionDal Permission { get; set; }
        public IRoleDal Role { get; set; }

        public async Task Save()
        {
            await _dbModel.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            _dbModel.Dispose();
        }
    }
}
