using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Bussiness.Interfaces
{
    public interface IAppUserService
    {
        Task<List<AppUser>> GetMembers();
        Task<List<AppUser>> GetAdmins();
        Task<List<AppUser>> GetModerators();
        Task<List<AppUser>> GetValidators();
        Task<List<AppUser>> GetWriters();
        Task<List<AppUser>> GetUsersByYaziId(int id);
    }
}
