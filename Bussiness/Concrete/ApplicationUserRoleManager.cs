using Bussiness.Interfaces;
using Data.Interfaces;
using DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ApplicationUserRoleManager: GenericManager<ApplicationUserRole>, IApplicationUserRoleService
    {
        private readonly IApplicationUserRoleDal _ApplicationUserRoleDal;

        public ApplicationUserRoleManager(IApplicationUserRoleDal ApplicationUserRoleDal, IGenericDal<ApplicationUserRole> genericDAL) : base(genericDAL)
        {
            _ApplicationUserRoleDal = ApplicationUserRoleDal;
        }

        public async Task<AppUserWithRoleDto> GetirUserIdyKarşılıkGelenRoleIdYiAsync(int id)
        {
           return  await  _ApplicationUserRoleDal.GetirUserIdyKarşılıkGelenRoleIdYiAsync(id);
        }
    }
}
