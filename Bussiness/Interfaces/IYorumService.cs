using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IYorumService : IGenericService<Yorum>
    {
        Task<ICollection<Yorum>> GetirYorumsByYaziId(); 
    }
}
