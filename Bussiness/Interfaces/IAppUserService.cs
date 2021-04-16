using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using DTOs.Concrete.AppUserDtoS;
using Entities.Concrete;

namespace Bussiness.Interfaces
{
    public interface IAppUserService :IGenericService<AppUser>
    {
        Task<List<AppUser>> GetMembers();
        Task<List<AppUser>> GetAdmins();
        Task<List<AppUser>> GetModerators();
        Task<List<AppUser>> GetValidators();
        Task<List<AppUser>> GetWriters();
        Task<List<AppUser>> GetUsersByYaziId(int id);
        Task<List<AppUser>> GetAllUsers();
        



    }
}
