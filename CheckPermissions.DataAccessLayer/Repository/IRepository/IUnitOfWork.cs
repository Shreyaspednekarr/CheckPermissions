using CheckPermissions.DataAccessLayer.DAL.Interfaces;

namespace CheckPermissions.DataAccessLayer.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserDal User { get; }
        IApplicationDal Application { get; }
        IPermissionDal Permission { get; }
        IRoleDal Role { get; }
    }
}
