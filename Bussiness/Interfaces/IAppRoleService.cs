using System;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Bussiness.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> GetAdminRole();
        Task<AppRole> GetMemberRole();
        Task<AppRole> GetModeratorRole();
        Task<AppRole> GetValidatorRole();
        Task<AppRole> GetWriterRole();
        Task<AppRole> GetRoleById(int id);

    }
}
