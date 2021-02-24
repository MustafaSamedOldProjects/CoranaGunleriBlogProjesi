using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class YaziYorumManager : GenericManager<YaziYorum>, IYaziYorumService
    {
        private readonly IYaziYorumDal _yaziYorumDal;
        public YaziYorumManager(IYaziYorumDal yaziYorumDal, IGenericDal<YaziYorum> genericDal) :base(genericDal)
        {
            _yaziYorumDal = yaziYorumDal;
        }
    }
}
