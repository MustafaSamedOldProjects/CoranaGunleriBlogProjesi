using Data.Interfaces;
using DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IApplicationUserRoleService : IGenericService<ApplicationUserRole> 
    {
        Task<AppUserWithRoleDto> GetirUserIdyKarşılıkGelenRoleIdYiAsync(int id);

    }
}
