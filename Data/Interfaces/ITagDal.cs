using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITagDal : IGenericDal<Tag>
    {
        Task<ICollection<Tag>> GetirTagsByYaziId(int id);
    }
}
