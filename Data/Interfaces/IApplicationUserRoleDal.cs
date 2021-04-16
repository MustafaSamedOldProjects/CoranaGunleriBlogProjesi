using DTOs;
using Entities.Concrete;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IApplicationUserRoleDal: ITablo
    {
        Task<AppUserWithRoleDto> GetirUserIdyKarşılıkGelenRoleIdYiAsync(int id);
    }
}
