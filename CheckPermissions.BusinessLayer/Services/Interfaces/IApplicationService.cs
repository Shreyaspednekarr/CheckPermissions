﻿using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> Get(int applicationId);
        Task<bool> Get(CreateApplicationRequest request);
        Task<IEnumerable<Application>> GetAll();
        Task Create(CreateApplicationRequest request);
        Task Delete(int applicationId);
    }
}
