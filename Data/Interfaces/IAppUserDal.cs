using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Data.Interfaces
{
    public interface IAppUserDal
    {
        Task<List<AppUser>> GetMembers();
        Task<List<AppUser>> GetAdmins();
        Task<List<AppUser>> GetModerators();
        Task<List<AppUser>> GetValidators();
        Task<List<AppUser>> GetWriters();
    }
}
