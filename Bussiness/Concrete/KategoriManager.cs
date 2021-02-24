using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class KategoriManager : GenericManager<Kategori>, IKategoriService
    {
        private readonly IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal, IGenericDal<Kategori> genericDal) : base(genericDal) 
        {
            _kategoriDal = kategoriDal;
        }
        public async Task<List<Kategori>> GetKategorisHaveNoYazis()
        {
            return await _kategoriDal.GetKategorisHaveNoYazis();
        }

        public async Task<List<Kategori>> GetKategorisHaveYazis()
        {
            return await _kategoriDal.GetKategorisHaveYazis();
        }
    }
}
