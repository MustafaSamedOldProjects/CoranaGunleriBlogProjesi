using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class YaziKategoriManager : GenericManager<YaziKategori>,  IYaziKategoriService
    {
        private readonly IYaziKategoriDal _yaziKategoriDal;
        public YaziKategoriManager(IYaziKategoriDal yaziKategoriDaL,IGenericDal<YaziKategori> genericDal) : base(genericDal) 
        {
            _yaziKategoriDal = yaziKategoriDaL;
        }
    }
}
