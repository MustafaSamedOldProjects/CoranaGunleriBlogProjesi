using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Repositories
{
    public class EfYaziTagRepository : EfGenericRepository<YaziTag>, IYaziTagDal
    {
    }
}
