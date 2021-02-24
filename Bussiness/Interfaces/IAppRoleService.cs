using System;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Data.Interfaces
{
    public interface IAppRoleService
    {
        Task<AppRole> GetAdminRole();
        Task<AppRole> GetMemberRole();
        Task<AppRole> GetModeratorRole();
        Task<AppRole> GetValidatorRole();
        Task<AppRole> GetWriterRole();
    }
}
