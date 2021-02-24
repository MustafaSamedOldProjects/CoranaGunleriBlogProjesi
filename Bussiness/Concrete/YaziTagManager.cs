using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class YaziTagManager : GenericManager<YaziTag>, IYaziTagService
    {
        private readonly IYaziTagDal _yaziTagDal;
        public YaziTagManager(IYaziTagDal yaziTagDal, IGenericDal<YaziTag> genericDal) : base(genericDal)
        {

        }
    }
}
