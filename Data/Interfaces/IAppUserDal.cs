using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.Concrete.AppUserDtoS;
using Entities.Concrete;
using Entities.Interfaces;

namespace Data.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppUser>> GetMembers();
        Task<List<AppUser>> GetAdmins();
        Task<List<AppUser>> GetModerators();
        Task<List<AppUser>> GetValidators();
        Task<List<AppUser>> GetWriters();
        Task<List<AppUser>> GetUsersByYaziId(int id);
        //Task<List<AppUser>> GetUserWithRole();
        Task<List<AppUser>> GetAllUsers();
    }
}
