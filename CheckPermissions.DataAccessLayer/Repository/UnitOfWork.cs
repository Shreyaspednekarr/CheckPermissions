using CheckPermissions.DataAccessLayer.DAL.Interfaces;
using CheckPermissions.DataAccessLayer.Repository.IRepository;

namespace CheckPermissions.DataAccessLayer.Repository
{
    public class UnitOfWork(CheckPermissionsDbModel dbModel, IUserDal user, IApplicationDal application, IPermissionDal permission, IRoleDal role) : IUnitOfWork
    {
        private readonly CheckPermissionsDbModel _dbModel = dbModel ?? throw new ArgumentNullException(nameof(dbModel));

        public IUserDal User { get; set; } = user ?? throw new ArgumentNullException(nameof(user));
        public IApplicationDal Application { get; set; } = application ?? throw new ArgumentNullException(nameof(application));
        public IPermissionDal Permission { get; set; } = permission ?? throw new ArgumentNullException(nameof(permission));
        public IRoleDal Role { get; set; } = role ?? throw new ArgumentNullException(nameof(role));

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
