﻿using CheckPermissions.DataModel;
using CheckPermissions.DataModel.Requests;

namespace CheckPermissions.BusinessLayer.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> Get(int userId);
        Task<bool> IsExists(CreateRoleRequest request);
        Task<IEnumerable<Role>> GetAll();
        Task Create(CreateRoleRequest request);
        Task<bool> Delete(int roleId);
        Task Assign(AssignRoleRequest request);
    }
}
