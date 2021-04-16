using Bussiness.Interfaces;
using Data.Interfaces;
using DTOs.Concrete.AppUserDtoS;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class AppUserManager : GenericManager<AppUser>,IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal,IGenericDal<AppUser> genericDAL):base(genericDAL)
        {
            _appUserDal = appUserDal;
        }
        public async Task<List<AppUser>> GetAdmins()
        {
            return await _appUserDal.GetAdmins();
        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            return await _appUserDal.GetAllUsers();
        }

        public async Task<List<AppUser>> GetMembers()
        {
            return await _appUserDal.GetMembers();

        }

        public async Task<List<AppUser>> GetModerators()
        {
            return await _appUserDal.GetModerators();

        }

        public async Task<List<AppUser>> GetUsersByYaziId(int id )
        {
            return await _appUserDal.GetUsersByYaziId(id);
        }

      

        public async Task<List<AppUser>> GetValidators()
        {
            return await _appUserDal.GetValidators();

        }

        public async Task<List<AppUser>> GetWriters()
        {
            return await _appUserDal.GetWriters();

        }
    }
}
