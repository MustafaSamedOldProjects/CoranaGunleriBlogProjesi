using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager( IAppRoleDal appRoleDal, IGenericDal<AppRole> genericDAL) : base(genericDAL)
        {
            _appRoleDal = appRoleDal;
        }
        public async Task<AppRole> GetAdminRole()
        {
            return await _appRoleDal.GetAdminRole();
        }

        public async Task<AppRole> GetMemberRole()
        {
            return await _appRoleDal.GetMemberRole();
        }

        public async Task<AppRole> GetModeratorRole()
        {
            return await _appRoleDal.GetModeratorRole();
        }

        public Task<AppRole> GetRoleById(int id)
        {
            return _appRoleDal.GetRoleById(id);
        }

        public async Task<AppRole> GetValidatorRole()
        {
            return await _appRoleDal.GetValidatorRole();
        }

        public async Task<AppRole> GetWriterRole()
        {
            return await _appRoleDal.GetWriterRole();
        }
    }
}
