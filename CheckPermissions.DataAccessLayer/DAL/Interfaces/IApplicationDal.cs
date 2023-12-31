﻿using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.DataAccessLayer.DAL.Interfaces
{
    public interface IApplicationDal
    {
        Task<Application> Get(int applicationId);
        Task<bool> IsExists(CreateApplicationRequest request);
        Task<IEnumerable<Application>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task<bool> Delete(int applicationId);
    }
}
